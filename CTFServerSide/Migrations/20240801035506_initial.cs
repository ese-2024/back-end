using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CTFServerSide.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NecessaryKnowledges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Knowledge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NecessaryKnowledges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NecessaryKnowledges_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quests_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChallenges",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChallengeId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChallenges", x => new { x.UserId, x.ChallengeId });
                    table.ForeignKey(
                        name: "FK_UserChallenges_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChallenges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Command = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    QuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuests",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuests", x => new { x.UserId, x.QuestId });
                    table.ForeignKey(
                        name: "FK_UserQuests_Quests_QuestId",
                        column: x => x.QuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserQuests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "Description", "Level", "Title" },
                values: new object[,]
                {
                    { 1, "", 1, "Nível 1: Navegação e Comandos Básicos" },
                    { 2, "", 2, "Nível 2: Manipulação de Arquivos e Diretórios" },
                    { 3, "", 3, "Nível 3: Permissões e Processos" },
                    { 4, "", 4, "Nível 4: Ferramentas de Busca e Filtros" },
                    { 5, "", 5, "Nível 5: Arquivos e Diretórios Avançados" },
                    { 6, "", 6, "Nível 6: Redes e Segurança" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ChallengeId", "Link", "Title" },
                values: new object[,]
                {
                    { 1, 1, "https://www.guiafoca.org/guiaonline/iniciante/ch02s05.html", "Guia foca - Explicações básicas" },
                    { 2, 1, "", "Comandos Básicos do Linux" },
                    { 3, 2, "https://pt.wikibooks.org/wiki/Linux_Essencial/Li%C3%A7%C3%A3o_Manipula%C3%A7%C3%A3o_de_arquivos", "Manipulação de Arquivos no Linux" },
                    { 4, 2, "https://www.alura.com.br/artigos/entendendo-as-permissoes-no-linux", "Entendendo Permissões no Linux" },
                    { 5, 3, "https://www.hostinger.com.br/tutoriais/como-gerenciar-processos-no-linux-usando-linha-de-comando#:~:text=Para%20listar%20processos%20no%20Linux,processos%20por%20uso%20da%20CPU.", "Gerenciamento de Processos no Linux" },
                    { 6, 3, "https://www.alura.com.br/artigos/entendendo-as-permissoes-no-linux#:~:text=No%20Linux%2C%20conseguimos%20alterar%20a,diret%C3%B3rio%20e%20dos%20demais%20usu%C3%A1rios.", "Manipulando Permissões e Propriedades de Arquivos" },
                    { 7, 4, "", "Expressões Regulares no Linux" },
                    { 8, 4, "", "Comandos de Busca e Filtros no Linux" },
                    { 9, 5, "", "Manipulação Avançada de Arquivos e Diretórios" },
                    { 10, 5, "", "Compressão e Descompressão no Linux" },
                    { 11, 6, "", "Configuração de Rede no Linux" },
                    { 12, 6, "", "Monitoramento de Rede no Linux" },
                    { 13, 6, "", "Configuração de Firewall com iptables" }
                });

            migrationBuilder.InsertData(
                table: "NecessaryKnowledges",
                columns: new[] { "Id", "ChallengeId", "Knowledge" },
                values: new object[,]
                {
                    { 1, 1, "Navegação no sistema de arquivos" },
                    { 2, 1, "Listagem de diretórios e arquivos" },
                    { 3, 1, "Exibição do conteúdo de arquivos" },
                    { 4, 1, "Manual de comandos" },
                    { 5, 2, "Criação, cópia, movimentação e remoção de arquivos e diretórios" },
                    { 6, 2, "Conhecimento de caminhos absolutos e relativos" },
                    { 7, 2, "Permissões básicas de arquivos" },
                    { 8, 3, "Modificação de permissões e propriedades de arquivos" },
                    { 9, 3, "Gerenciamento básico de processos" },
                    { 10, 3, "Visualização de processos em execução" },
                    { 11, 4, "Uso de comandos de busca e filtros" },
                    { 12, 4, "Entendimento de expressões regulares básicas" },
                    { 13, 4, "Manipulação de fluxo de dados entre comandos" },
                    { 14, 5, "Manipulação avançada de arquivos e diretórios" },
                    { 15, 5, "Compressão e descompressão de arquivos" },
                    { 16, 5, "Montagem e desmontagem de sistemas de arquivos" },
                    { 17, 6, "Configuração básica de rede" },
                    { 18, 6, "Ferramentas de monitoramento de rede" },
                    { 19, 6, "Configurações de firewall" },
                    { 20, 6, "Noções de segurança e criptografia" }
                });

            migrationBuilder.InsertData(
                table: "Quests",
                columns: new[] { "Id", "ChallengeId", "Description", "IsCompleted", "Order", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Ana está no diretório /home/ana e precisa listar todos os arquivos e diretórios que estão nesse local para encontrar um arquivo chamado 'instrucoes.txt'.", false, 1, "Explorador de Diretórios" },
                    { 2, 1, "Carlos encontrou um arquivo chamado 'mensagem.txt' no diretório atual. Ele precisa ler o conteúdo desse arquivo para encontrar uma pista.", false, 2, "Leitura de Arquivo" },
                    { 3, 1, "Beatriz precisa usar o comando cp para copiar um arquivo, mas ela não sabe como usá-lo corretamente. Ela decide consultar o manual do comando.", false, 3, "Manual de Comandos" },
                    { 4, 1, "Eduardo está navegando pelo sistema de arquivos e quer saber em qual diretório ele está atualmente.", false, 4, "Caminho Atual" },
                    { 5, 1, "Fernanda precisa entrar no diretório 'documentos' que está localizado dentro de seu diretório pessoal.", false, 5, "Movendo-se pelos Diretórios" },
                    { 6, 2, "Guilherme precisa criar um arquivo chamado 'novo_arquivo.txt' no diretório atual.", false, 1, "Criando um Arquivo" },
                    { 7, 2, "Helena precisa fazer uma cópia do arquivo 'documento.txt' e chamá-la de 'documento_backup.txt'.", false, 2, "Copiando um Arquivo" },
                    { 8, 2, "Isabel quer mover o arquivo 'relatorio.txt' para o diretório 'relatorios'.", false, 3, "Movendo um Arquivo" },
                    { 9, 2, "João precisa deletar o arquivo 'temp.txt' que está no diretório atual.", false, 4, "Removendo um Arquivo" },
                    { 10, 2, "Karina precisa criar um diretório chamado 'projetos' em seu diretório pessoal.", false, 5, "Criando um Diretório" },
                    { 11, 3, "Leonardo precisa dar permissão de leitura, escrita e execução ao dono do arquivo 'script.sh'.", false, 1, "Alterando Permissões" },
                    { 12, 3, "Mariana precisa mudar o dono do arquivo 'dados.txt' para o usuário 'pedro'.", false, 2, "Mudando o Dono do Arquivo" },
                    { 13, 3, "Nicolas quer ver uma lista de todos os processos que estão sendo executados no sistema.", false, 3, "Visualizando Processos em Execução" },
                    { 14, 3, "Olivia identificou que um processo está travando o sistema e precisa encerrá-lo. O PID do processo é 1234.", false, 4, "Matando um Processo" },
                    { 15, 3, "Pedro quer executar o comando backup.sh em segundo plano.", false, 5, "Executando um Comando em Background" },
                    { 16, 4, "Ricardo precisa encontrar um arquivo chamado 'config.txt' em seu diretório pessoal.", false, 1, "Buscando por Arquivos" },
                    { 17, 4, "Sabrina quer encontrar todas as ocorrências da palavra 'erro' no arquivo 'log.txt'.", false, 2, "Buscando Texto em Arquivos" },
                    { 18, 4, "Thiago precisa saber quantas linhas o arquivo 'dados.csv' possui.", false, 3, "Contando Linhas de um Arquivo" },
                    { 19, 4, "Vanessa quer ordenar as linhas do arquivo 'nomes.txt' em ordem alfabética.", false, 4, "Ordenando Linhas de um Arquivo" },
                    { 20, 4, "Wagner precisa remover as linhas duplicadas do arquivo 'lista.txt'.", false, 5, "Eliminando Linhas Duplicadas" },
                    { 21, 5, "Xuxa precisa criar um arquivo compactado chamado 'backup.tar.gz' a partir do diretório 'projetos'.", false, 1, "Compactando Arquivos" },
                    { 22, 5, "Yuri recebeu um arquivo chamado 'dados.tar.gz' e precisa extrair seu conteúdo.", false, 2, "Descompactando Arquivos" },
                    { 23, 5, "Zara precisa montar o sistema de arquivos localizado em '/dev/sdb1' no diretório '/mnt/usb'.", false, 3, "Montando um Sistema de Arquivos" },
                    { 24, 5, "Amanda terminou de usar o sistema de arquivos montado em '/mnt/usb' e precisa desmontá-lo.", false, 4, "Desmontando um Sistema de Arquivos" },
                    { 25, 5, "Bruno precisa mudar o dono do diretório 'projetos' e de todos os arquivos e subdiretórios para o usuário 'juliana'.", false, 5, "Alterando o Dono de um Diretório Recursivamente" },
                    { 26, 6, "Carlos quer verificar as conexões de rede ativas em seu sistema.", false, 1, "Verificando Conexões de Rede" },
                    { 27, 6, "Daniela precisa verificar se consegue se conectar ao servidor 'example.com'.", false, 2, "Pinging um Servidor" },
                    { 28, 6, "Eduardo precisa configurar a interface de rede 'eth0' com o endereço IP '192.168.1.100'.", false, 3, "Configurando uma Interface de Rede" },
                    { 29, 6, "Fernanda precisa bloquear todo o tráfego de entrada na porta 80.", false, 4, "Adicionando uma Regra de Firewall" },
                    { 30, 6, "Gabriel quer monitorar o uso de rede de sua interface 'wlan0'.", false, 5, "Monitorando o Uso de Rede" }
                });

            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "Command", "Description", "ExpectedAnswer", "IsCompleted", "Order", "QuestId" },
                values: new object[,]
                {
                    { 1, "ls", "", "ls /home/ana", false, 1, 1 },
                    { 2, "cat", "", "cat mensagem.txt", false, 1, 2 },
                    { 3, "man", "", "man cp", false, 1, 3 },
                    { 4, "pwd", "", "pwd", false, 1, 4 },
                    { 5, "cd", "", "cd ~/documentos", false, 1, 5 },
                    { 6, "touch", "", "touch novo_arquivo.txt", false, 1, 6 },
                    { 7, "cp", "", "cp documento.txt documento_backup.txt", false, 1, 7 },
                    { 8, "mv", "", "mv relatorio.txt relatorios/", false, 1, 8 },
                    { 9, "rm", "", "rm temp.txt", false, 1, 9 },
                    { 10, "mkdir", "", "mkdir ~/projetos", false, 1, 10 },
                    { 11, "chmod", "", "chmod u+rwx script.sh", false, 1, 11 },
                    { 12, "chown", "", "sudo chown pedro dados.txt", false, 1, 12 },
                    { 13, "ps", "", "ps aux", false, 1, 13 },
                    { 14, "kill", "", "kill 1234", false, 1, 14 },
                    { 15, "./backup.sh &", "", "./backup.sh &", false, 1, 15 },
                    { 16, "find", "", "find ~/ -name config.txt", false, 1, 16 },
                    { 17, "grep", "", "grep 'erro' log.txt", false, 1, 17 },
                    { 18, "wc", "", "wc -l dados.csv", false, 1, 18 },
                    { 19, "sort", "", "sort nomes.txt", false, 1, 19 },
                    { 20, "uniq", "", "uniq lista.txt", false, 1, 20 },
                    { 21, "tar", "", "tar -czvf backup.tar.gz projetos/", false, 1, 21 },
                    { 22, "tar", "", "tar -xzvf dados.tar.gz", false, 1, 22 },
                    { 23, "mount", "", "sudo mount /dev/sdb1 /mnt/usb", false, 1, 23 },
                    { 24, "umount", "", "sudo umount /mnt/usb", false, 1, 24 },
                    { 25, "chown", "", "sudo chown -R juliana projetos/", false, 1, 25 },
                    { 26, "netstat", "", "netstat -tuln", false, 1, 26 },
                    { 27, "ping", "", "ping example.com", false, 1, 27 },
                    { 28, "ifconfig", "", "sudo ifconfig eth0 192.168.1.100", false, 1, 28 },
                    { 29, "iptables", "", "sudo iptables -A INPUT -p tcp --dport 80 -j DROP", false, 1, 29 },
                    { 30, "iftop", "", "sudo iftop -i wlan0", false, 1, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ChallengeId",
                table: "Materials",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_NecessaryKnowledges_ChallengeId",
                table: "NecessaryKnowledges",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_ChallengeId",
                table: "Quests",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_QuestId",
                table: "Steps",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChallenges_ChallengeId",
                table: "UserChallenges",
                column: "ChallengeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuests_QuestId",
                table: "UserQuests",
                column: "QuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "NecessaryKnowledges");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "UserChallenges");

            migrationBuilder.DropTable(
                name: "UserQuests");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Challenges");
        }
    }
}
