# LemonLab 🍋 - Manga Library Manager

Um gerenciador moderno e completo de biblioteca de mangás local, desenvolvido com .NET 9, Avalonia UI, SQLite, Python e outras tecnologias. Inspirado em Tachiyomi, AniList e MyAnimeList.

![LemonLab](https://img.shields.io/badge/Version-1.0.0-yellow)
![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![Avalonia](https://img.shields.io/badge/Avalonia-11.3.6-blue)
![License](https://img.shields.io/badge/License-Personal-green)

## 🎯 Características Principais

### 📚 Biblioteca Completa
- **Scan Automático**: Escaneie pastas locais para indexar mangás automaticamente
- **Formatos Suportados**: .cbz, .cbr, .zip, .pdf, .rar, .7z
- **Busca Inteligente**: Pesquise por título, autor ou gênero
- **Filtros Avançados**: Filtre por status de leitura
- **Cards Visuais**: Interface moderna com cards coloridos

### 👤 Perfil do Usuário
- **Estatísticas Detalhadas**: Total de mangás, média de notas, distribuição por status
- **Top 5 Mangás**: Veja seus mangás mais bem avaliados
- **Edição de Perfil**: Personalize seu nome de usuário
- **Sem Login Online**: Tudo funciona localmente

### ⚙️ Configurações Avançadas
- **Tema Claro/Escuro**: Alterne entre temas com persistência
- **Diretório Customizável**: Escolha onde seus mangás estão armazenados
- **Exportar/Importar**: Faça backup dos seus dados em JSON
- **Reset de Dados**: Opção para limpar banco de dados

### 📊 Gerenciamento de Mangás
- **Status de Leitura**: Lendo, Completo, Pausado, Abandonado, Planejar Ler
- **Sistema de Notas**: Avalie de 0 a 10
- **Reviews**: Escreva comentários sobre cada mangá
- **Progresso**: Acompanhe capítulos lidos
- **Metadados**: Título, autor, gênero, formato, tamanho do arquivo

## 🏗️ Arquitetura do Projeto

```
LemonLab/
├── Models/                 # Modelos de dados
│   ├── Manga.cs           # Modelo principal de mangá
│   ├── UserProfile.cs     # Perfil do usuário
│   └── AppSettings.cs     # Configurações do app
├── ViewModels/            # ViewModels (MVVM)
│   ├── ViewModelBase.cs   # Classe base
│   ├── LibraryViewModel.cs
│   ├── ProfileViewModel.cs
│   ├── SettingsViewModel.cs
│   └── RelayCommand.cs    # Implementação de ICommand
├── Views/                 # Views (XAML)
│   ├── LibraryView.axaml
│   ├── ProfileView.axaml
│   └── SettingsView.axaml
├── Services/              # Serviços
│   ├── DatabaseService.cs      # SQLite
│   ├── ConfigService.cs        # JSON Config
│   └── MangaScannerService.cs  # Scanner de arquivos
├── Scripts/               # Scripts auxiliares
│   └── manga_scanner.py   # Python scanner
├── Styles/                # Estilos XAML
│   └── AppStyles.axaml    # Estilos globais
├── Assets/                # Recursos visuais
├── Data/                  # Banco de dados e configs
│   ├── lemonlab.db        # SQLite database
│   └── config.json        # Configurações
├── MainWindow.axaml       # Janela principal
├── MainViewModel.cs       # ViewModel principal
├── App.axaml              # Aplicação
└── Program.cs             # Entry point
```

## 🛠️ Tecnologias Utilizadas

### Linguagens e Frameworks
- **C# (.NET 9.0)**: Linguagem principal e framework
- **Avalonia UI 11.3.6**: Framework UI cross-platform (XAML)
- **Python 3.x**: Scripts auxiliares para scanning
- **SQL**: Queries para SQLite
- **JSON**: Armazenamento de configurações

### Bibliotecas e Dependências
- **Microsoft.Data.Sqlite**: Banco de dados local
- **Avalonia.Themes.Fluent**: Tema moderno
- **Avalonia.Fonts.Inter**: Fonte Inter
- **System.Text.Json**: Serialização JSON

### Padrões e Arquitetura
- **MVVM (Model-View-ViewModel)**: Separação de responsabilidades
- **Repository Pattern**: Acesso a dados
- **Command Pattern**: Comandos de UI
- **Dependency Injection**: Injeção de serviços

## 🚀 Como Executar

### Pré-requisitos
- .NET 9.0 SDK ou superior
- Windows, macOS ou Linux
- Python 3.x (opcional, para scripts auxiliares)

### Instalação

1. **Clone ou baixe o projeto**
```bash
cd LemonLab
```

2. **Restaure as dependências**
```bash
dotnet restore
```

3. **Execute o projeto**
```bash
dotnet run
```

### Build para Produção
```bash
dotnet publish -c Release -r win-x64 --self-contained
```

## 🎨 Design e Interface

### Paleta de Cores
- **Amarelo Limão (Accent)**: #FBBF24
- **Preto**: #111827
- **Branco**: #FFFFFF
- **Cinza Escuro**: #1F2937
- **Cinza Claro**: #F9FAFB

### Componentes UI
- **Menu Lateral Fixo**: Navegação entre Biblioteca, Perfil e Configurações
- **Cards Modernos**: Design limpo com sombras e bordas arredondadas
- **Botões Interativos**: Hover effects e transições suaves
- **Tema Responsivo**: Adapta-se ao tema claro/escuro

### Tipografia
- **Fonte**: Inter (incluída com Avalonia)
- **Tamanhos**: 11px a 32px
- **Pesos**: Regular, Medium, SemiBold, Bold

## 📖 Funcionalidades Detalhadas

### Biblioteca
1. **Adicionar Mangás**: Clique em "Escanear Pasta" e selecione o diretório
2. **Buscar**: Digite no campo de busca para filtrar
3. **Filtrar**: Use os chips de filtro para ver por status
4. **Visualizar**: Clique em um card para ver detalhes

### Perfil
1. **Editar Nome**: Clique no ícone de lápis ao lado do nome
2. **Ver Estatísticas**: Visualize total, completos, lendo e média
3. **Top 5**: Veja seus mangás favoritos

### Configurações
1. **Tema**: Alterne entre claro e escuro
2. **Diretório**: Configure onde seus mangás estão
3. **Exportar**: Salve backup em JSON
4. **Reset**: Limpe dados (cuidado!)

## 🔧 Scripts Python

### manga_scanner.py
Script auxiliar para escanear diretórios e extrair metadados.

**Uso:**
```bash
python Scripts/manga_scanner.py "C:\Meus Mangás"
```

**Funcionalidades:**
- Escaneia recursivamente
- Extrai título e autor do nome do arquivo
- Conta páginas em arquivos comprimidos
- Exporta para JSON

## 💾 Banco de Dados

### Estrutura SQLite

**Tabela: Mangas**
- Id, Title, Author, FilePath, CoverPath
- Status, Rating, Review
- CurrentChapter, TotalChapters
- DateAdded, LastRead
- Genre, FileFormat, FileSize

**Tabela: UserProfile**
- Id, Username, MemberSince

## 🔐 Armazenamento de Dados

### Localização
- **Windows**: `C:\Users\[User]\LemonLab\Data\`
- **Linux**: `~/.local/share/LemonLab/Data/`
- **macOS**: `~/Library/Application Support/LemonLab/Data/`

### Arquivos
- `lemonlab.db`: Banco de dados SQLite
- `config.json`: Configurações do aplicativo

## 🎯 Roadmap Futuro

- [ ] Suporte a capas personalizadas
- [ ] Leitor de mangás integrado
- [ ] Sincronização em nuvem (opcional)
- [ ] Importação de listas do MyAnimeList
- [ ] Sistema de tags customizadas
- [ ] Gráficos de estatísticas
- [ ] Notificações de novos capítulos
- [ ] Modo de leitura offline
- [ ] Integração com APIs de mangás
- [ ] Suporte a múltiplos idiomas

## 🐛 Solução de Problemas

### Erro ao escanear
- Verifique se o diretório existe
- Confirme que os arquivos têm extensões suportadas
- Execute como administrador se necessário

### Banco de dados corrompido
- Use "Reset Banco de Dados" nas configurações
- Ou delete manualmente `Data/lemonlab.db`

### Tema não muda
- Salve as configurações após alternar
- Reinicie o aplicativo

## 📝 Licença

Projeto de uso pessoal. Sinta-se livre para modificar e usar.

## 🤝 Contribuições

Este é um projeto pessoal, mas sugestões são bem-vindas!

## 📧 Contato

Desenvolvido com 🍋 e ❤️

---

**LemonLab v1.0.0** - Seu gerenciador pessoal de mangás
