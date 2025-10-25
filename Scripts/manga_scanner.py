#!/usr/bin/env python3
"""
LemonLab - Manga Scanner Script
Script auxiliar para escanear e extrair metadados de mangás
"""

import os
import sys
import json
import zipfile
import rarfile
from pathlib import Path
from typing import List, Dict, Optional

# Formatos suportados
SUPPORTED_FORMATS = ['.cbz', '.cbr', '.zip', '.pdf', '.rar', '.7z']

def scan_directory(directory: str) -> List[Dict]:
    """
    Escaneia um diretório em busca de arquivos de mangá
    """
    manga_files = []
    
    if not os.path.exists(directory):
        print(f"Erro: Diretório não encontrado: {directory}", file=sys.stderr)
        return manga_files
    
    for root, dirs, files in os.walk(directory):
        for file in files:
            file_path = os.path.join(root, file)
            ext = os.path.splitext(file)[1].lower()
            
            if ext in SUPPORTED_FORMATS:
                manga_info = extract_manga_info(file_path)
                if manga_info:
                    manga_files.append(manga_info)
    
    return manga_files

def extract_manga_info(file_path: str) -> Optional[Dict]:
    """
    Extrai informações de um arquivo de mangá
    """
    try:
        file_name = os.path.basename(file_path)
        file_size = os.path.getsize(file_path)
        ext = os.path.splitext(file_name)[1].lower()
        
        # Parse do nome do arquivo
        title, author = parse_filename(file_name)
        
        # Tenta contar páginas
        page_count = count_pages(file_path, ext)
        
        manga_info = {
            'title': title,
            'author': author,
            'file_path': file_path,
            'file_size': file_size,
            'file_format': ext.replace('.', '').upper(),
            'page_count': page_count,
            'date_added': None  # Será preenchido pelo C#
        }
        
        return manga_info
        
    except Exception as e:
        print(f"Erro ao processar {file_path}: {e}", file=sys.stderr)
        return None

def parse_filename(filename: str) -> tuple:
    """
    Extrai título e autor do nome do arquivo
    Formatos: "Title - Author", "Title by Author", "Title (Author)"
    """
    name = os.path.splitext(filename)[0]
    title = name
    author = "Desconhecido"
    
    if ' - ' in name:
        parts = name.split(' - ', 1)
        title = parts[0].strip()
        if len(parts) > 1:
            author = parts[1].strip()
    elif ' by ' in name:
        parts = name.split(' by ', 1)
        title = parts[0].strip()
        if len(parts) > 1:
            author = parts[1].strip()
    elif '(' in name and ')' in name:
        start = name.index('(')
        end = name.index(')')
        if start < end:
            title = name[:start].strip()
            author = name[start+1:end].strip()
    
    return title, author

def count_pages(file_path: str, ext: str) -> int:
    """
    Conta o número de páginas em um arquivo comprimido
    """
    try:
        if ext in ['.cbz', '.zip']:
            with zipfile.ZipFile(file_path, 'r') as zf:
                # Conta arquivos de imagem
                image_extensions = ['.jpg', '.jpeg', '.png', '.gif', '.webp', '.bmp']
                pages = [f for f in zf.namelist() 
                        if any(f.lower().endswith(img_ext) for img_ext in image_extensions)]
                return len(pages)
        
        elif ext in ['.cbr', '.rar']:
            try:
                with rarfile.RarFile(file_path, 'r') as rf:
                    image_extensions = ['.jpg', '.jpeg', '.png', '.gif', '.webp', '.bmp']
                    pages = [f for f in rf.namelist() 
                            if any(f.lower().endswith(img_ext) for img_ext in image_extensions)]
                    return len(pages)
            except:
                return 0
        
    except Exception as e:
        print(f"Erro ao contar páginas de {file_path}: {e}", file=sys.stderr)
    
    return 0

def export_to_json(manga_files: List[Dict], output_path: str):
    """
    Exporta a lista de mangás para JSON
    """
    try:
        with open(output_path, 'w', encoding='utf-8') as f:
            json.dump(manga_files, f, indent=2, ensure_ascii=False)
        print(f"Exportado {len(manga_files)} mangás para {output_path}")
    except Exception as e:
        print(f"Erro ao exportar JSON: {e}", file=sys.stderr)

def main():
    if len(sys.argv) < 2:
        print("Uso: python manga_scanner.py <diretório>")
        sys.exit(1)
    
    directory = sys.argv[1]
    output_path = sys.argv[2] if len(sys.argv) > 2 else "manga_scan_results.json"
    
    print(f"Escaneando diretório: {directory}")
    manga_files = scan_directory(directory)
    
    print(f"Encontrados {len(manga_files)} arquivos de mangá")
    
    if manga_files:
        export_to_json(manga_files, output_path)
    
    return 0

if __name__ == "__main__":
    sys.exit(main())
