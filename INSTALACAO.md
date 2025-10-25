# 📦 Guia de Instalação - LemonLab

## Requisitos do Sistema

### Mínimos
- **Sistema Operacional**: Windows 10/11, Linux (Ubuntu 20.04+), macOS 10.15+
- **RAM**: 2 GB
- **Espaço em Disco**: 500 MB (aplicativo) + espaço para mangás
- **.NET Runtime**: 9.0 ou superior
- **Resolução**: 1024x768 ou superior

### Recomendados
- **Sistema Operacional**: Windows 11, Linux (Ubuntu 22.04+), macOS 12+
- **RAM**: 4 GB ou mais
- **Espaço em Disco**: 1 GB + espaço para mangás
- **Resolução**: 1920x1080 ou superior
- **Python**: 3.8+ (opcional, para scripts auxiliares)

## Instalação do .NET 9.0

### Windows

1. **Download do .NET SDK**
   - Acesse: https://dotnet.microsoft.com/download/dotnet/9.0
   - Baixe o instalador para Windows (x64)
   - Execute o instalador e siga as instruções

2. **Verificar Instalação**
   ```powershell
   dotnet --version
   ```
   Deve exibir: `9.0.xxx`

### Linux (Ubuntu/Debian)

```bash
# Adicionar repositório Microsoft
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# Instalar .NET SDK
sudo apt-get update
sudo apt-get install -y dotnet-sdk-9.0

# Verificar
dotnet --version
```

### macOS

```bash
# Usando Homebrew
brew install --cask dotnet-sdk

# Verificar
dotnet --version
```

## Instalação do LemonLab

### Opção 1: Executar do Código Fonte (Desenvolvimento)

1. **Clone ou baixe o projeto**
   ```bash
   cd C:\Users\JP\LemonLab
   ```

2. **Restaurar dependências**
   ```bash
   dotnet restore
   ```

3. **Compilar o projeto**
   ```bash
   dotnet build
   ```

4. **Executar**
   ```bash
   dotnet run
   ```

### Opção 2: Build Standalone (Produção)

#### Windows

```powershell
# Build para Windows x64 (standalone)
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true

# O executável estará em:
# bin\Release\net9.0\win-x64\publish\LemonLab.exe
```

#### Linux

```bash
# Build para Linux x64
dotnet publish -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true

# O executável estará em:
# bin/Release/net9.0/linux-x64/publish/LemonLab
```

#### macOS

```bash
# Build para macOS x64
dotnet publish -c Release -r osx-x64 --self-contained -p:PublishSingleFile=true

# O executável estará em:
# bin/Release/net9.0/osx-x64/publish/LemonLab
```

### Opção 3: Instalação Portátil

1. **Baixe o release compilado** (quando disponível)
2. **Extraia para uma pasta**
   ```
   C:\Program Files\LemonLab\
   ```
3. **Execute LemonLab.exe**

## Instalação do Python (Opcional)

O Python é opcional e usado apenas para scripts auxiliares de scanning avançado.

### Windows

1. **Download**
   - Acesse: https://www.python.org/downloads/
   - Baixe Python 3.11 ou superior
   - ⚠️ **IMPORTANTE**: Marque "Add Python to PATH"

2. **Instalar dependências**
   ```powershell
   pip install rarfile
   ```

### Linux

```bash
# Ubuntu/Debian
sudo apt-get install python3 python3-pip

# Instalar dependências
pip3 install rarfile
```

### macOS

```bash
# Python já vem instalado, mas recomenda-se usar Homebrew
brew install python3

# Instalar dependências
pip3 install rarfile
```

## Configuração Inicial

### Primeira Execução

1. **Inicie o LemonLab**
   ```bash
   dotnet run
   ```

2. **Configure o diretório de mangás**
   - Vá para **Configurações**
   - Em "Diretório dos Mangás", clique em **📁 Procurar**
   - Selecione a pasta onde seus mangás estão armazenados
   - Clique em **💾 Salvar Configurações**

3. **Escaneie sua biblioteca**
   - Vá para **Biblioteca**
   - Clique em **📁 Escanear Pasta**
   - Aguarde o scan completar

### Estrutura de Pastas Criada

Após a primeira execução, o LemonLab cria:

```
%APPDATA%\LemonLab\  (ou ~/.local/share/LemonLab/ no Linux)
├── Data\
│   ├── lemonlab.db      # Banco de dados SQLite
│   └── config.json      # Configurações
└── Logs\                # Logs (futuro)
```

## Organização dos Mangás

### Estrutura Recomendada

```
Mangás\
├── One Piece\
│   ├── One Piece - Vol 01.cbz
│   ├── One Piece - Vol 02.cbz
│   └── ...
├── Berserk\
│   ├── Berserk - Vol 01.cbr
│   └── ...
└── Vinland Saga\
    ├── Vinland Saga - Vol 01.pdf
    └── ...
```

### Nomenclatura de Arquivos

Para melhor reconhecimento automático:

✅ **Bom:**
- `One Piece - Eiichiro Oda.cbz`
- `Berserk by Kentaro Miura.cbr`
- `Vinland Saga (Makoto Yukimura).pdf`

❌ **Evite:**
- `manga1.cbz`
- `arquivo.zip`
- `download (1).pdf`

## Formatos Suportados

O LemonLab suporta os seguintes formatos:

| Formato | Extensão | Descrição |
|---------|----------|-----------|
| Comic Book ZIP | `.cbz` | Arquivo ZIP com imagens |
| Comic Book RAR | `.cbr` | Arquivo RAR com imagens |
| ZIP Archive | `.zip` | Arquivo ZIP genérico |
| PDF Document | `.pdf` | Documento PDF |
| RAR Archive | `.rar` | Arquivo RAR genérico |
| 7-Zip Archive | `.7z` | Arquivo 7-Zip |

## Solução de Problemas na Instalação

### Erro: "dotnet não é reconhecido"

**Causa**: .NET não está no PATH

**Solução**:
1. Reinstale o .NET SDK
2. Marque a opção "Add to PATH"
3. Reinicie o terminal/prompt

### Erro: "The framework 'Microsoft.NETCore.App', version '9.0.0' was not found"

**Causa**: Versão incorreta do .NET

**Solução**:
```bash
# Verificar versão instalada
dotnet --list-sdks

# Instalar .NET 9.0
# Siga as instruções de instalação acima
```

### Erro: "Access denied" ao criar banco de dados

**Causa**: Permissões insuficientes

**Solução**:
- **Windows**: Execute como Administrador
- **Linux/Mac**: 
  ```bash
  chmod +x LemonLab
  ```

### Erro: "Python not found" ao usar scripts

**Causa**: Python não instalado ou não no PATH

**Solução**:
- Instale o Python seguindo as instruções acima
- Ou ignore - os scripts Python são opcionais

### Aplicativo não abre no Linux

**Causa**: Falta de dependências gráficas

**Solução**:
```bash
# Ubuntu/Debian
sudo apt-get install libx11-dev libice-dev libsm-dev

# Fedora
sudo dnf install libX11-devel libICE-devel libSM-devel
```

## Desinstalação

### Windows

1. **Remover aplicativo**
   - Delete a pasta do LemonLab
   - Delete `%APPDATA%\LemonLab\`

2. **Remover .NET (opcional)**
   - Painel de Controle > Programas > Desinstalar
   - Procure por ".NET SDK"

### Linux

```bash
# Remover aplicativo
rm -rf ~/LemonLab
rm -rf ~/.local/share/LemonLab

# Remover .NET (opcional)
sudo apt-get remove dotnet-sdk-9.0
```

### macOS

```bash
# Remover aplicativo
rm -rf ~/LemonLab
rm -rf ~/Library/Application\ Support/LemonLab

# Remover .NET (opcional)
brew uninstall dotnet-sdk
```

## Atualização

### Atualizar do Código Fonte

```bash
cd C:\Users\JP\LemonLab

# Fazer backup dos dados
# Copie a pasta Data\ para um local seguro

# Atualizar código
git pull  # Se usando Git

# Recompilar
dotnet build

# Executar
dotnet run
```

### Atualizar Build Standalone

1. **Backup dos dados**
   - Vá para **Configurações** > **Exportar Dados**
   - Salve o backup

2. **Baixe a nova versão**

3. **Substitua os arquivos**
   - Mantenha a pasta `Data\`
   - Substitua o executável

4. **Execute a nova versão**

## Migração de Dados

### De outra máquina

1. **Na máquina antiga**:
   - Abra LemonLab
   - Vá para **Configurações** > **Exportar Dados**
   - Copie os arquivos exportados

2. **Na máquina nova**:
   - Instale o LemonLab
   - Vá para **Configurações** > **Importar Dados**
   - Selecione os arquivos exportados

### De outro aplicativo

Atualmente não há importação direta de outros aplicativos. Você precisará:
1. Reorganizar seus mangás na estrutura recomendada
2. Escanear novamente no LemonLab
3. Adicionar manualmente notas e reviews

## Performance e Otimização

### Melhorar Performance do Scan

1. **Use SSD**: Armazene mangás em SSD
2. **Organize pastas**: Evite muitos arquivos em uma única pasta
3. **Use formatos comprimidos**: .cbz e .cbr são mais rápidos que .pdf

### Reduzir Uso de Memória

1. **Feche outros aplicativos** durante o scan
2. **Escaneie em lotes** se tiver muitos mangás
3. **Use filtros** para carregar menos dados na UI

## Suporte e Comunidade

### Reportar Problemas

Se encontrar problemas:
1. Verifique este guia de instalação
2. Consulte a documentação técnica
3. Crie uma issue no repositório com:
   - Versão do LemonLab
   - Sistema operacional
   - Descrição do problema
   - Logs (se disponíveis)

### Obter Ajuda

- **Documentação**: Leia `README.md` e `GUIA_DE_USO.md`
- **FAQ**: Consulte a seção de perguntas frequentes
- **Comunidade**: Participe das discussões (futuro)

## Próximos Passos

Após a instalação:

1. ✅ Configure o diretório de mangás
2. ✅ Escaneie sua biblioteca
3. ✅ Explore as funcionalidades
4. ✅ Personalize as configurações
5. ✅ Faça backup regular dos dados

---

**LemonLab v1.0.0** - Guia de Instalação Completo

Desenvolvido com 🍋 e ❤️
