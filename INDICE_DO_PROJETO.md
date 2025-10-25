# 📑 Índice Completo do Projeto - LemonLab

## 📁 Estrutura de Arquivos

### 🔧 Arquivos de Configuração
```
├── .gitignore                    # Arquivos ignorados pelo Git
├── LICENSE                       # Licença MIT
├── LemonLab.csproj              # Arquivo de projeto .NET
├── LemonLab.sln                 # Solution do Visual Studio
├── app.manifest                 # Manifesto da aplicação Windows
└── Program.cs                   # Entry point da aplicação
```

### 📚 Documentação (8 arquivos)
```
├── README.md                    # Visão geral do projeto
├── README_COMPLETO.md           # Documentação extensa e detalhada
├── GUIA_DE_USO.md              # Manual completo do usuário
├── INSTALACAO.md               # Guia de instalação multiplataforma
├── DOCUMENTACAO_TECNICA.md     # Referência técnica completa
├── CHANGELOG.md                # Histórico de versões
├── SUMARIO_EXECUTIVO.md        # Sumário executivo do projeto
├── COMANDOS_UTEIS.md           # Comandos úteis para desenvolvimento
└── INDICE_DO_PROJETO.md        # Este arquivo
```

### 🎨 Interface (XAML)
```
├── App.axaml                    # Configuração da aplicação
├── App.axaml.cs                # Code-behind da aplicação
├── MainWindow.axaml            # Janela principal com menu lateral
└── MainWindow.axaml.cs         # Code-behind da janela principal
```

### 🧩 Models (3 arquivos)
```
Models/
├── Manga.cs                     # Modelo de dados do mangá
├── UserProfile.cs              # Modelo do perfil do usuário
└── AppSettings.cs              # Modelo de configurações
```

### 🎯 ViewModels (5 arquivos)
```
ViewModels/
├── ViewModelBase.cs            # Classe base para ViewModels
├── LibraryViewModel.cs         # Lógica da biblioteca
├── ProfileViewModel.cs         # Lógica do perfil
├── SettingsViewModel.cs        # Lógica das configurações
└── RelayCommand.cs             # Implementação de ICommand
```

### 🖼️ Views (6 arquivos)
```
Views/
├── LibraryView.axaml           # Interface da biblioteca
├── LibraryView.axaml.cs        # Code-behind da biblioteca
├── ProfileView.axaml           # Interface do perfil
├── ProfileView.axaml.cs        # Code-behind do perfil
├── SettingsView.axaml          # Interface de configurações
└── SettingsView.axaml.cs       # Code-behind de configurações
```

### ⚙️ Services (3 arquivos)
```
Services/
├── DatabaseService.cs          # Serviço de banco de dados SQLite
├── ConfigService.cs            # Serviço de configurações JSON
└── MangaScannerService.cs      # Serviço de scan de arquivos
```

### 🎨 Styles (1 arquivo)
```
Styles/
└── AppStyles.axaml             # Estilos globais da aplicação
```

### 🐍 Scripts (1 arquivo)
```
Scripts/
└── manga_scanner.py            # Script Python para scan avançado
```

### 💾 Data (Gerado em runtime)
```
Data/
├── lemonlab.db                 # Banco de dados SQLite (gerado)
├── config.json                 # Configurações do usuário (gerado)
└── config.example.json         # Exemplo de configuração
```

### 📦 Assets (Recursos)
```
Assets/
└── (vazio - para recursos futuros)
```

### 🔨 Build (Gerado)
```
bin/                            # Arquivos compilados
obj/                            # Arquivos intermediários
```

## 📊 Estatísticas do Projeto

### Arquivos por Tipo
- **C# (.cs)**: 15 arquivos
- **XAML (.axaml)**: 8 arquivos
- **Markdown (.md)**: 9 arquivos
- **Python (.py)**: 1 arquivo
- **JSON (.json)**: 1 arquivo exemplo
- **Configuração**: 5 arquivos

**Total de Arquivos de Código**: ~30 arquivos

### Linhas de Código (Aproximado)
- **C#**: ~3.500 linhas
- **XAML**: ~1.500 linhas
- **Python**: ~200 linhas
- **Documentação**: ~3.000 linhas

**Total**: ~8.200 linhas

## 🗂️ Organização por Funcionalidade

### 1. Core da Aplicação
```
Program.cs                      # Entry point
App.axaml + App.axaml.cs       # Configuração global
MainWindow.axaml + .cs         # Janela principal
MainViewModel.cs               # ViewModel principal
```

### 2. Camada de Dados
```
Models/
├── Manga.cs                    # Entidade principal
├── UserProfile.cs             # Perfil do usuário
└── AppSettings.cs             # Configurações

Services/
├── DatabaseService.cs         # Acesso ao SQLite
├── ConfigService.cs           # Gerenciamento de configs
└── MangaScannerService.cs     # Indexação de arquivos
```

### 3. Camada de Apresentação
```
ViewModels/
├── ViewModelBase.cs           # Base class
├── LibraryViewModel.cs        # Lógica da biblioteca
├── ProfileViewModel.cs        # Lógica do perfil
├── SettingsViewModel.cs       # Lógica de configurações
└── RelayCommand.cs            # Commands

Views/
├── LibraryView.axaml + .cs    # UI da biblioteca
├── ProfileView.axaml + .cs    # UI do perfil
└── SettingsView.axaml + .cs   # UI de configurações
```

### 4. Estilos e Recursos
```
Styles/
└── AppStyles.axaml            # Estilos globais

Assets/
└── (recursos visuais)
```

### 5. Scripts Auxiliares
```
Scripts/
└── manga_scanner.py           # Scanner Python
```

### 6. Documentação
```
README.md                      # Visão geral
README_COMPLETO.md            # Documentação completa
GUIA_DE_USO.md               # Manual do usuário
INSTALACAO.md                # Guia de instalação
DOCUMENTACAO_TECNICA.md      # Referência técnica
CHANGELOG.md                 # Histórico de versões
SUMARIO_EXECUTIVO.md         # Sumário executivo
COMANDOS_UTEIS.md            # Comandos úteis
INDICE_DO_PROJETO.md         # Este arquivo
```

## 📖 Guia de Navegação

### Para Começar
1. Leia `README.md` - Visão geral
2. Siga `INSTALACAO.md` - Instalar dependências
3. Execute `dotnet run` - Iniciar aplicação
4. Consulte `GUIA_DE_USO.md` - Aprender a usar

### Para Desenvolver
1. Estude `DOCUMENTACAO_TECNICA.md` - Arquitetura
2. Consulte `COMANDOS_UTEIS.md` - Comandos
3. Explore `Models/` - Entender dados
4. Analise `ViewModels/` - Lógica de negócio
5. Modifique `Views/` - Interface

### Para Entender o Código
```
Fluxo de Execução:
1. Program.cs → Inicia aplicação
2. App.axaml.cs → Configura app
3. MainWindow.axaml → Cria janela
4. MainViewModel.cs → Inicializa serviços
5. Views/ → Renderiza interface
6. ViewModels/ → Processa lógica
7. Services/ → Acessa dados
8. Models/ → Representa entidades
```

## 🔍 Localização Rápida

### Precisa Modificar...

#### Interface?
- **Menu Lateral**: `MainWindow.axaml` (linhas 20-90)
- **Biblioteca**: `Views/LibraryView.axaml`
- **Perfil**: `Views/ProfileView.axaml`
- **Configurações**: `Views/SettingsView.axaml`
- **Estilos**: `Styles/AppStyles.axaml`

#### Lógica?
- **Navegação**: `MainViewModel.cs`
- **Biblioteca**: `ViewModels/LibraryViewModel.cs`
- **Perfil**: `ViewModels/ProfileViewModel.cs`
- **Configurações**: `ViewModels/SettingsViewModel.cs`

#### Dados?
- **Modelo Mangá**: `Models/Manga.cs`
- **Banco de Dados**: `Services/DatabaseService.cs`
- **Configurações**: `Services/ConfigService.cs`
- **Scanner**: `Services/MangaScannerService.cs`

#### Documentação?
- **Uso**: `GUIA_DE_USO.md`
- **Instalação**: `INSTALACAO.md`
- **Técnica**: `DOCUMENTACAO_TECNICA.md`
- **Comandos**: `COMANDOS_UTEIS.md`

## 📋 Checklist de Arquivos

### Essenciais ✅
- [x] Program.cs
- [x] App.axaml + App.axaml.cs
- [x] MainWindow.axaml + MainWindow.axaml.cs
- [x] MainViewModel.cs
- [x] LemonLab.csproj
- [x] README.md

### Models ✅
- [x] Manga.cs
- [x] UserProfile.cs
- [x] AppSettings.cs

### ViewModels ✅
- [x] ViewModelBase.cs
- [x] LibraryViewModel.cs
- [x] ProfileViewModel.cs
- [x] SettingsViewModel.cs
- [x] RelayCommand.cs

### Views ✅
- [x] LibraryView.axaml + .cs
- [x] ProfileView.axaml + .cs
- [x] SettingsView.axaml + .cs

### Services ✅
- [x] DatabaseService.cs
- [x] ConfigService.cs
- [x] MangaScannerService.cs

### Estilos ✅
- [x] AppStyles.axaml

### Scripts ✅
- [x] manga_scanner.py

### Documentação ✅
- [x] README.md
- [x] README_COMPLETO.md
- [x] GUIA_DE_USO.md
- [x] INSTALACAO.md
- [x] DOCUMENTACAO_TECNICA.md
- [x] CHANGELOG.md
- [x] SUMARIO_EXECUTIVO.md
- [x] COMANDOS_UTEIS.md
- [x] INDICE_DO_PROJETO.md

### Configuração ✅
- [x] .gitignore
- [x] LICENSE
- [x] LemonLab.sln
- [x] app.manifest

## 🎯 Arquivos Mais Importantes

### Top 10 Arquivos para Entender o Projeto
1. **README.md** - Visão geral
2. **MainViewModel.cs** - Coordenação central
3. **DatabaseService.cs** - Persistência de dados
4. **Manga.cs** - Modelo principal
5. **LibraryViewModel.cs** - Lógica da biblioteca
6. **MainWindow.axaml** - Interface principal
7. **LibraryView.axaml** - UI da biblioteca
8. **AppStyles.axaml** - Estilos visuais
9. **DOCUMENTACAO_TECNICA.md** - Referência técnica
10. **GUIA_DE_USO.md** - Como usar

## 📦 Dependências Externas

### NuGet Packages
- Avalonia (11.3.6)
- Avalonia.Desktop (11.3.6)
- Avalonia.Themes.Fluent (11.3.6)
- Avalonia.Fonts.Inter (11.3.6)
- Microsoft.Data.Sqlite (9.0.0)
- Avalonia.Diagnostics (11.3.6) - Debug only

### Python Packages (Opcional)
- rarfile

## 🔄 Fluxo de Dados

```
Usuário → View (XAML)
         ↓
    ViewModel (Lógica)
         ↓
    Service (Negócio)
         ↓
    Database/Config (Persistência)
         ↓
    Model (Dados)
```

## 📝 Convenções de Nomenclatura

### Arquivos
- **Models**: `NomeDoModelo.cs`
- **ViewModels**: `NomeViewModel.cs`
- **Views**: `NomeView.axaml` + `NomeView.axaml.cs`
- **Services**: `NomeService.cs`
- **Docs**: `NOME_EM_MAIUSCULA.md`

### Classes
- **PascalCase**: Classes, métodos, propriedades
- **camelCase**: Variáveis locais, parâmetros
- **_camelCase**: Campos privados

## 🎓 Recursos de Aprendizado

### Para Iniciantes
1. Leia `README.md`
2. Siga `INSTALACAO.md`
3. Execute o projeto
4. Explore `GUIA_DE_USO.md`

### Para Desenvolvedores
1. Estude `DOCUMENTACAO_TECNICA.md`
2. Analise a estrutura MVVM
3. Explore os Services
4. Modifique e teste

### Para Contribuidores
1. Leia `CHANGELOG.md`
2. Consulte `COMANDOS_UTEIS.md`
3. Siga padrões do código
4. Documente mudanças

---

**LemonLab v1.0.0** - Índice Completo do Projeto

**Total de Arquivos**: ~40 arquivos  
**Linhas de Código**: ~8.200 linhas  
**Documentação**: ~3.000 linhas  
**Status**: ✅ Completo e Funcional

Desenvolvido com 🍋 e ❤️
