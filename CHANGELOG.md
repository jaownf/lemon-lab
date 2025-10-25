# 📝 Changelog - LemonLab

Todas as mudanças notáveis neste projeto serão documentadas neste arquivo.

O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/),
e este projeto adere ao [Semantic Versioning](https://semver.org/lang/pt-BR/).

## [1.0.0] - 2025-10-25

### 🎉 Lançamento Inicial

Primeira versão estável do LemonLab - Gerenciador de Biblioteca de Mangás.

### ✨ Adicionado

#### Interface e UX
- Interface moderna com Avalonia UI 11.3.6
- Menu lateral fixo com navegação entre Biblioteca, Perfil e Configurações
- Design responsivo com paleta amarelo-limão, preto, branco e cinza
- Cards visuais para exibição de mangás
- Animações suaves e transições
- Tema claro com suporte futuro para tema escuro

#### Biblioteca de Mangás
- Sistema de scan automático de diretórios
- Suporte a múltiplos formatos: .cbz, .cbr, .zip, .pdf, .rar, .7z
- Busca inteligente por título, autor e gênero
- Filtros por status de leitura
- Visualização em grid com cards
- Informações detalhadas de cada mangá
- Progresso de leitura por capítulos

#### Gerenciamento de Mangás
- 5 status de leitura: Planejar Ler, Lendo, Completo, Pausado, Abandonado
- Sistema de avaliação de 0 a 10
- Campo de review/comentários
- Rastreamento de capítulos lidos
- Metadados automáticos: título, autor, formato, tamanho
- Data de adição e última leitura

#### Perfil do Usuário
- Estatísticas detalhadas de leitura
- Total de mangás na biblioteca
- Contagem por status
- Média de avaliações
- Top 5 mangás mais bem avaliados
- Edição de nome de usuário
- Data de cadastro

#### Configurações
- Configuração de diretório de mangás
- Toggle para scan automático na inicialização
- Opção de mostrar splash screen
- Exportação de dados em JSON
- Importação de backups
- Reset de banco de dados
- Reset de configurações

#### Banco de Dados
- SQLite para armazenamento local
- Tabela de mangás com todos os metadados
- Tabela de perfil do usuário
- Queries otimizadas com índices
- Transações seguras
- Prevenção de SQL injection

#### Serviços e Backend
- DatabaseService para operações CRUD
- ConfigService para gerenciamento de JSON
- MangaScannerService para indexação de arquivos
- Parsing inteligente de nomes de arquivos
- Detecção automática de autor e título
- Validação de formatos suportados

#### Scripts Auxiliares
- Script Python para scan avançado (manga_scanner.py)
- Contagem de páginas em arquivos comprimidos
- Extração de metadados
- Exportação para JSON
- Suporte a ZIP e RAR

#### Arquitetura
- Padrão MVVM (Model-View-ViewModel)
- Separação clara de responsabilidades
- ViewModels: Library, Profile, Settings
- Models: Manga, UserProfile, AppSettings
- Services: Database, Config, Scanner
- RelayCommand para bindings
- INotifyPropertyChanged para reatividade

#### Documentação
- README completo com features e instruções
- Guia de uso detalhado
- Documentação técnica completa
- Guia de instalação para Windows, Linux e macOS
- Changelog versionado
- Exemplos de configuração

#### Estilos e Temas
- Sistema de estilos centralizado (AppStyles.axaml)
- Recursos de cores dinâmicos
- Estilos para botões: primary, secondary, danger, icon-button
- Estilos para menu lateral
- Estilos para cards de mangá
- Estilos para filtros e chips
- Hover effects e transições

### 🔧 Técnico

#### Dependências
- .NET 9.0
- Avalonia 11.3.6
- Avalonia.Desktop 11.3.6
- Avalonia.Themes.Fluent 11.3.6
- Avalonia.Fonts.Inter 11.3.6
- Microsoft.Data.Sqlite 9.0.0
- System.Text.Json (built-in)

#### Estrutura do Projeto
```
LemonLab/
├── Models/          # Entidades de dados
├── ViewModels/      # Lógica de apresentação
├── Views/           # Interfaces XAML
├── Services/        # Serviços de negócio
├── Scripts/         # Scripts Python
├── Styles/          # Estilos XAML
├── Assets/          # Recursos visuais
└── Data/            # Banco de dados e configs
```

#### Performance
- Operações assíncronas para não bloquear UI
- ObservableCollection para updates automáticos
- Lazy loading de dados
- Queries otimizadas
- Indexação no SQLite

#### Segurança
- Parâmetros SQL para prevenir injection
- Validação de caminhos de arquivo
- Validação de inputs do usuário
- Try-catch em operações críticas
- Transações atômicas no banco

### 📚 Formatos Suportados

- Comic Book ZIP (.cbz)
- Comic Book RAR (.cbr)
- ZIP Archive (.zip)
- PDF Document (.pdf)
- RAR Archive (.rar)
- 7-Zip Archive (.7z)

### 🌍 Plataformas

- ✅ Windows 10/11 (x64)
- ✅ Linux (x64) - Ubuntu 20.04+
- ✅ macOS (x64) - 10.15+

### 📖 Documentação Incluída

- `README.md` - Visão geral e features
- `README_COMPLETO.md` - Documentação extensa
- `GUIA_DE_USO.md` - Manual do usuário
- `INSTALACAO.md` - Guia de instalação
- `DOCUMENTACAO_TECNICA.md` - Referência técnica
- `CHANGELOG.md` - Histórico de versões

### 🎯 Casos de Uso

1. **Colecionador Casual**: Organize sua coleção pessoal de mangás
2. **Leitor Ávido**: Acompanhe progresso e avaliações
3. **Arquivista**: Mantenha biblioteca organizada com metadados
4. **Estatísticas**: Visualize suas estatísticas de leitura

### 🔒 Privacidade

- ✅ 100% local - nenhum dado enviado para servidores
- ✅ Sem telemetria ou tracking
- ✅ Sem login ou conta online necessária
- ✅ Seus dados permanecem no seu computador

### 🐛 Problemas Conhecidos

Nenhum problema crítico conhecido na v1.0.0.

### 📝 Notas

- Esta é a primeira versão estável
- Tema escuro será implementado em versão futura
- Leitor de mangás integrado planejado para v1.2
- Sincronização em nuvem opcional planejada para v2.0

---

## [Não Lançado]

### 🚀 Planejado para v1.1

#### Adicionado
- [ ] Tema escuro completo
- [ ] Sistema de logging
- [ ] Atalhos de teclado
- [ ] Splash screen animada
- [ ] Notificações no sistema
- [ ] Suporte a múltiplos idiomas
- [ ] Importação de listas do MyAnimeList

#### Melhorado
- [ ] Performance do scanner
- [ ] UI/UX refinamentos
- [ ] Busca mais inteligente
- [ ] Filtros avançados
- [ ] Ordenação customizável

#### Corrigido
- [ ] Bugs reportados pela comunidade

### 🎨 Planejado para v1.2

#### Adicionado
- [ ] Leitor de mangás integrado
- [ ] Suporte a capas personalizadas
- [ ] Upload de imagens de capa
- [ ] Sistema de tags customizadas
- [ ] Categorias e coleções
- [ ] Gráficos de estatísticas
- [ ] Exportação de relatórios

#### Melhorado
- [ ] Cache de imagens
- [ ] Paginação avançada
- [ ] Zoom e navegação no leitor
- [ ] Marcadores de página

### 🌐 Planejado para v2.0

#### Adicionado
- [ ] Sincronização em nuvem (opcional)
- [ ] API REST
- [ ] Aplicativo mobile (Avalonia Mobile)
- [ ] Sistema de plugins
- [ ] Integração com APIs de mangás
- [ ] Download automático de metadados
- [ ] Recomendações baseadas em leitura
- [ ] Compartilhamento de listas

#### Melhorado
- [ ] Arquitetura modular
- [ ] Extensibilidade
- [ ] Performance geral

---

## Tipos de Mudanças

- **Adicionado**: Novas funcionalidades
- **Alterado**: Mudanças em funcionalidades existentes
- **Descontinuado**: Funcionalidades que serão removidas
- **Removido**: Funcionalidades removidas
- **Corrigido**: Correção de bugs
- **Segurança**: Correções de vulnerabilidades

## Versionamento

O projeto segue [Semantic Versioning](https://semver.org/):

- **MAJOR**: Mudanças incompatíveis na API
- **MINOR**: Novas funcionalidades compatíveis
- **PATCH**: Correções de bugs compatíveis

Exemplo: v1.2.3
- 1 = Major (mudanças grandes)
- 2 = Minor (novas features)
- 3 = Patch (bug fixes)

---

**LemonLab** - Desenvolvido com 🍋 e ❤️

Para reportar bugs ou sugerir features, abra uma issue no repositório.
