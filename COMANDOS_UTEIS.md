# 🛠️ Comandos Úteis - LemonLab

## Comandos Básicos

### Executar o Projeto
```bash
# Executar em modo desenvolvimento
dotnet run

# Executar com hot reload
dotnet watch run
```

### Build e Compilação
```bash
# Build Debug
dotnet build

# Build Release
dotnet build -c Release

# Limpar build
dotnet clean

# Restaurar dependências
dotnet restore
```

### Publicação

#### Windows
```powershell
# Build standalone (arquivo único)
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true

# Build framework-dependent (menor)
dotnet publish -c Release -r win-x64

# Build com otimizações
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -p:PublishTrimmed=true
```

#### Linux
```bash
# Ubuntu/Debian x64
dotnet publish -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true

# ARM64 (Raspberry Pi)
dotnet publish -c Release -r linux-arm64 --self-contained -p:PublishSingleFile=true
```

#### macOS
```bash
# Intel x64
dotnet publish -c Release -r osx-x64 --self-contained -p:PublishSingleFile=true

# Apple Silicon (M1/M2)
dotnet publish -c Release -r osx-arm64 --self-contained -p:PublishSingleFile=true
```

## Gerenciamento de Dependências

### Adicionar Pacotes
```bash
# Adicionar pacote NuGet
dotnet add package NomeDoPacote

# Adicionar versão específica
dotnet add package NomeDoPacote --version 1.0.0

# Listar pacotes instalados
dotnet list package
```

### Atualizar Pacotes
```bash
# Atualizar todos os pacotes
dotnet add package NomeDoPacote

# Verificar pacotes desatualizados
dotnet list package --outdated
```

### Remover Pacotes
```bash
# Remover pacote
dotnet remove package NomeDoPacote
```

## Scripts Python

### Executar Scanner
```bash
# Escanear diretório
python Scripts/manga_scanner.py "C:\Caminho\Para\Mangás"

# Escanear e exportar para arquivo específico
python Scripts/manga_scanner.py "C:\Caminho\Para\Mangás" "resultado.json"

# Com Python 3 explícito
python3 Scripts/manga_scanner.py "C:\Caminho\Para\Mangás"
```

### Instalar Dependências Python
```bash
# Windows
pip install rarfile

# Linux/macOS
pip3 install rarfile

# Com requirements.txt (se existir)
pip install -r requirements.txt
```

## Banco de Dados

### Acessar SQLite
```bash
# Abrir banco de dados
sqlite3 Data/lemonlab.db

# Comandos úteis no SQLite
.tables              # Listar tabelas
.schema Mangas       # Ver estrutura da tabela
SELECT * FROM Mangas LIMIT 10;  # Ver primeiros 10 mangás
.exit                # Sair
```

### Backup Manual
```bash
# Windows
copy Data\lemonlab.db Data\lemonlab_backup.db

# Linux/macOS
cp Data/lemonlab.db Data/lemonlab_backup.db
```

### Restaurar Backup
```bash
# Windows
copy Data\lemonlab_backup.db Data\lemonlab.db

# Linux/macOS
cp Data/lemonlab_backup.db Data/lemonlab.db
```

## Git (Controle de Versão)

### Inicializar Repositório
```bash
# Inicializar Git
git init

# Adicionar todos os arquivos
git add .

# Primeiro commit
git commit -m "Initial commit - LemonLab v1.0.0"
```

### Commits
```bash
# Ver status
git status

# Adicionar arquivos específicos
git add arquivo.cs

# Commit com mensagem
git commit -m "Descrição da mudança"

# Ver histórico
git log --oneline
```

### Branches
```bash
# Criar nova branch
git checkout -b feature/nova-funcionalidade

# Trocar de branch
git checkout main

# Listar branches
git branch

# Deletar branch
git branch -d nome-da-branch
```

### Remote
```bash
# Adicionar remote
git remote add origin https://github.com/usuario/lemonlab.git

# Push para remote
git push -u origin main

# Pull do remote
git pull origin main
```

## Testes (Futuro)

### Executar Testes
```bash
# Executar todos os testes
dotnet test

# Executar com cobertura
dotnet test /p:CollectCoverage=true

# Executar testes específicos
dotnet test --filter "FullyQualifiedName~MangaTests"
```

## Limpeza

### Limpar Arquivos Temporários
```bash
# Limpar build
dotnet clean

# Remover bin e obj (Windows)
rmdir /s /q bin obj

# Remover bin e obj (Linux/macOS)
rm -rf bin obj
```

### Limpar Dados do Usuário
```bash
# CUIDADO: Remove todos os dados!

# Windows
rmdir /s /q Data

# Linux/macOS
rm -rf Data
```

## Debugging

### Executar com Logs Detalhados
```bash
# Logs verbosos
dotnet run --verbosity detailed

# Logs de diagnóstico
dotnet run --verbosity diagnostic
```

### Variáveis de Ambiente
```bash
# Windows (PowerShell)
$env:DOTNET_ENVIRONMENT="Development"
dotnet run

# Linux/macOS
DOTNET_ENVIRONMENT=Development dotnet run
```

## Performance

### Análise de Performance
```bash
# Build com otimizações
dotnet build -c Release

# Executar com profiling (requer ferramentas)
dotnet trace collect -- dotnet run
```

### Reduzir Tamanho do Build
```bash
# Trimming (remove código não usado)
dotnet publish -c Release -r win-x64 --self-contained -p:PublishTrimmed=true

# ReadyToRun (otimização AOT)
dotnet publish -c Release -r win-x64 --self-contained -p:PublishReadyToRun=true
```

## Utilitários

### Verificar Versões
```bash
# Versão do .NET
dotnet --version

# Listar SDKs instalados
dotnet --list-sdks

# Listar runtimes instalados
dotnet --list-runtimes

# Informações do sistema
dotnet --info
```

### Criar Estrutura de Projeto
```bash
# Criar novo projeto Avalonia
dotnet new avalonia.app -n NomeDoProjeto

# Criar solution
dotnet new sln -n NomeDaSolution

# Adicionar projeto à solution
dotnet sln add NomeDoProjeto/NomeDoProjeto.csproj
```

## Manutenção

### Atualizar .NET
```bash
# Verificar atualizações
dotnet sdk check

# Após instalar nova versão, atualizar projeto
# Edite o .csproj e mude <TargetFramework>
```

### Verificar Problemas
```bash
# Verificar problemas no projeto
dotnet format --verify-no-changes

# Formatar código automaticamente
dotnet format
```

## Atalhos do Visual Studio Code

### Comandos Úteis
- `Ctrl+Shift+B` - Build
- `F5` - Debug
- `Ctrl+F5` - Run sem debug
- `Ctrl+Shift+P` - Command Palette
- `Ctrl+K Ctrl+C` - Comentar linha
- `Ctrl+K Ctrl+U` - Descomentar linha

### Terminal Integrado
- `Ctrl+`` - Abrir/fechar terminal
- `Ctrl+Shift+`` - Novo terminal

## Scripts Personalizados

### Criar Script de Build (Windows)
```powershell
# build.ps1
Write-Host "Building LemonLab..." -ForegroundColor Green
dotnet clean
dotnet restore
dotnet build -c Release
Write-Host "Build completed!" -ForegroundColor Green
```

### Criar Script de Build (Linux/macOS)
```bash
#!/bin/bash
# build.sh
echo "Building LemonLab..."
dotnet clean
dotnet restore
dotnet build -c Release
echo "Build completed!"
```

### Executar Scripts
```bash
# Windows
.\build.ps1

# Linux/macOS (dar permissão primeiro)
chmod +x build.sh
./build.sh
```

## Troubleshooting

### Erro: "Port already in use"
```bash
# Windows - Encontrar processo na porta
netstat -ano | findstr :5000
taskkill /PID <PID> /F

# Linux/macOS
lsof -i :5000
kill -9 <PID>
```

### Erro: "Access Denied"
```bash
# Windows - Executar como Admin
# Clique direito > Executar como Administrador

# Linux/macOS
sudo dotnet run
```

### Erro: "Database locked"
```bash
# Fechar todas as instâncias do app
# Windows
taskkill /IM LemonLab.exe /F

# Linux/macOS
pkill -9 LemonLab
```

## Comandos Rápidos

### Desenvolvimento Diário
```bash
# Iniciar desenvolvimento
dotnet restore && dotnet run

# Build rápido
dotnet build

# Limpar e rebuild
dotnet clean && dotnet build
```

### Deploy Rápido
```bash
# Build para produção (Windows)
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o publish/

# Copiar para pasta de instalação
xcopy /E /I /Y publish\* "C:\Program Files\LemonLab\"
```

### Backup Rápido
```bash
# Backup completo (Windows)
xcopy /E /I /Y Data\* Backup\Data_%date:~-4,4%%date:~-10,2%%date:~-7,2%\

# Backup completo (Linux/macOS)
cp -r Data/ Backup/Data_$(date +%Y%m%d)/
```

## Recursos Adicionais

### Documentação
- [.NET Documentation](https://docs.microsoft.com/dotnet/)
- [Avalonia Documentation](https://docs.avaloniaui.net/)
- [SQLite Documentation](https://www.sqlite.org/docs.html)

### Ferramentas Úteis
- **Visual Studio Code**: Editor recomendado
- **Rider**: IDE alternativa
- **DB Browser for SQLite**: Visualizar banco de dados
- **Git**: Controle de versão

---

**LemonLab v1.0.0** - Comandos Úteis

Para mais informações, consulte a documentação completa.
