# 📖 Guia de Uso - LemonLab

## Primeiros Passos

### 1. Iniciando o Aplicativo

Execute o comando:
```bash
dotnet run
```

Ou abra o executável compilado em `bin/Debug/net9.0/LemonLab.exe`

### 2. Interface Principal

O LemonLab possui três seções principais acessíveis pelo menu lateral:

#### 📚 Biblioteca
- Visualize todos os seus mangás
- Busque por título, autor ou gênero
- Filtre por status de leitura
- Adicione novos mangás escaneando pastas

#### 👤 Perfil
- Veja suas estatísticas de leitura
- Edite seu nome de usuário
- Confira seus top 5 mangás
- Acompanhe seu progresso

#### ⚙️ Configurações
- Alterne entre tema claro e escuro
- Configure o diretório dos mangás
- Exporte e importe seus dados
- Gerencie o banco de dados

## Como Adicionar Mangás

### Método 1: Scan Automático (Recomendado)

1. Organize seus mangás em uma pasta
2. Nomeie os arquivos seguindo um dos padrões:
   - `Título - Autor.cbz`
   - `Título by Autor.cbz`
   - `Título (Autor).cbz`
3. Na aba **Biblioteca**, clique em **"📁 Escanear Pasta"**
4. Selecione o diretório onde estão seus mangás
5. Aguarde o scan completar

### Método 2: Script Python

Se você tem Python instalado, pode usar o script auxiliar:

```bash
python Scripts/manga_scanner.py "C:\Caminho\Para\Seus\Mangás"
```

O script irá:
- Escanear recursivamente o diretório
- Extrair metadados dos arquivos
- Contar páginas em arquivos comprimidos
- Gerar um relatório JSON

## Gerenciando Mangás

### Editando Informações

1. Clique em um mangá na biblioteca
2. No painel de detalhes, você pode:
   - Alterar o status de leitura
   - Dar uma nota de 0 a 10
   - Escrever uma review
   - Atualizar o progresso de capítulos

### Status de Leitura

- **Planejar Ler** (Cinza): Mangás que você pretende ler
- **Lendo** (Verde): Mangás em progresso
- **Completo** (Azul): Mangás finalizados
- **Pausado** (Amarelo): Mangás temporariamente pausados
- **Abandonado** (Vermelho): Mangás que você desistiu

### Sistema de Notas

- **0-3**: Ruim
- **4-5**: Mediano
- **6-7**: Bom
- **8-9**: Ótimo
- **10**: Obra-prima

## Busca e Filtros

### Busca Rápida

Digite no campo de busca para encontrar mangás por:
- Título (ex: "One Piece")
- Autor (ex: "Oda")
- Gênero (ex: "Action")

### Filtros por Status

Use os chips de filtro para ver apenas:
- Todos os mangás
- Mangás que você está lendo
- Mangás completos
- Mangás pausados
- Mangás abandonados
- Mangás planejados

## Perfil e Estatísticas

### Editando seu Perfil

1. Vá para a aba **Perfil**
2. Clique no ícone de lápis ✏️ ao lado do seu nome
3. Digite o novo nome
4. Clique em ✓ para salvar ou ✕ para cancelar

### Entendendo as Estatísticas

- **Total de Mangás**: Quantidade total na sua biblioteca
- **Completos**: Mangás que você terminou de ler
- **Lendo**: Mangás em progresso atual
- **Média**: Sua nota média para todos os mangás avaliados

### Top 5 Mangás

Os 5 mangás com as maiores notas aparecem destacados no seu perfil.

## Configurações

### Tema Claro/Escuro

1. Vá para **Configurações**
2. Ative/desative o **Tema Escuro**
3. As configurações são salvas automaticamente

### Diretório dos Mangás

1. Em **Configurações**, vá para **Biblioteca**
2. Clique em **📁 Procurar**
3. Selecione a pasta onde seus mangás estão
4. Clique em **💾 Salvar Configurações**

### Exportar Dados

Para fazer backup:

1. Vá para **Configurações** > **Gerenciar Dados**
2. Clique em **📤 Exportar Dados**
3. Os arquivos serão salvos em `Documentos/LemonLab_Export/`
4. Dois arquivos serão criados:
   - `lemonlab_backup_[data].db` (banco de dados)
   - `lemonlab_backup_[data].json` (configurações)

### Importar Dados

Para restaurar um backup:

1. Vá para **Configurações** > **Gerenciar Dados**
2. Clique em **📥 Importar Dados**
3. Selecione o arquivo `.db` ou `.json`
4. Confirme a importação

### Resetar Dados

⚠️ **ATENÇÃO**: Esta ação não pode ser desfeita!

Para limpar todos os dados:

1. Vá para **Configurações** > **Zona de Perigo**
2. Clique em **🗑️ Resetar Banco de Dados**
3. Confirme a ação

Isso irá:
- Remover todos os mangás
- Limpar estatísticas
- Resetar o perfil

## Formatos Suportados

O LemonLab suporta os seguintes formatos de arquivo:

- **.cbz** (Comic Book ZIP)
- **.cbr** (Comic Book RAR)
- **.zip** (ZIP Archive)
- **.pdf** (PDF Document)
- **.rar** (RAR Archive)
- **.7z** (7-Zip Archive)

## Dicas e Truques

### Organização de Arquivos

Para melhor reconhecimento automático, organize assim:

```
Mangás/
├── One Piece - Eiichiro Oda/
│   ├── One Piece Vol 01.cbz
│   ├── One Piece Vol 02.cbz
│   └── ...
├── Berserk - Kentaro Miura/
│   ├── Berserk Vol 01.cbz
│   └── ...
└── ...
```

### Nomenclatura Recomendada

- **Bom**: `Título - Autor.cbz`
- **Bom**: `Título by Autor.cbz`
- **Bom**: `Título (Autor).cbz`
- **Evite**: `manga123.cbz` (sem informações)

### Backup Regular

Recomendamos exportar seus dados:
- Semanalmente se você adiciona muitos mangás
- Mensalmente para uso casual
- Antes de atualizar o aplicativo

### Performance

Para melhor performance:
- Mantenha os mangás em um SSD
- Evite pastas com mais de 1000 arquivos
- Use formatos comprimidos (.cbz, .cbr)

## Atalhos de Teclado

*Em desenvolvimento - futura atualização*

## Solução de Problemas

### Mangás não aparecem após scan

1. Verifique se os arquivos têm extensões suportadas
2. Confirme que o diretório está correto
3. Tente escanear novamente
4. Verifique as permissões da pasta

### Erro ao abrir o aplicativo

1. Verifique se o .NET 9.0 está instalado
2. Execute como administrador
3. Verifique se o banco de dados não está corrompido
4. Tente resetar as configurações

### Tema não muda

1. Salve as configurações após alternar
2. Reinicie o aplicativo
3. Verifique se o arquivo `config.json` existe em `Data/`

### Estatísticas incorretas

1. Vá para **Perfil**
2. Clique no botão 🔄 para atualizar
3. Se persistir, vá para **Biblioteca** e clique em **🔄 Atualizar**

## Suporte

Para reportar bugs ou sugerir melhorias:
- Crie uma issue no repositório
- Descreva o problema detalhadamente
- Inclua screenshots se possível

## Próximas Atualizações

Fique atento para:
- Leitor de mangás integrado
- Suporte a capas personalizadas
- Sincronização em nuvem (opcional)
- Importação de listas do MyAnimeList
- Sistema de tags customizadas
- Gráficos de estatísticas avançados

---

**LemonLab v1.0.0** - Desenvolvido com 🍋 e ❤️
