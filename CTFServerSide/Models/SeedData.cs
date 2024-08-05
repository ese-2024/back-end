using Microsoft.EntityFrameworkCore;
using CTFServerSide.Models;

namespace CTFServerSide.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seeds para Challenges
            modelBuilder.Entity<Challenge>().HasData(
                new Challenge { Id = 1, Description = "", Title = "Navegação e Comandos Básicos", Level = 1 },
                new Challenge { Id = 2, Description = "", Title = "Manipulação de Arquivos e Diretórios", Level = 2 },
                new Challenge { Id = 3, Description = "", Title = "Permissões e Processos", Level = 3 },
                new Challenge { Id = 4, Description = "", Title = "Ferramentas de Busca e Filtros", Level = 4 },
                new Challenge { Id = 5, Description = "", Title = "Arquivos e Diretórios Avançados", Level = 5 },
                new Challenge { Id = 6, Description = "", Title = "Redes e Segurança", Level = 6 }
            );

            // Seeds para Quests
            modelBuilder.Entity<Quest>().HasData(
                // Nível 1 Quests
                new Quest { Id = 1, Order = 1, Title = "Explorador de Diretórios", ChallengeId = 1, Description = "Ana está no diretório /home/ana e precisa listar todos os arquivos e diretórios que estão nesse local para encontrar um arquivo chamado 'instrucoes.txt'." },
                new Quest { Id = 2, Order = 2, Title = "Leitura de Arquivo", ChallengeId = 1, Description = "Carlos encontrou um arquivo chamado 'mensagem.txt' no diretório atual. Ele precisa ler o conteúdo desse arquivo para encontrar uma pista." },
                new Quest { Id = 3, Order = 3, Title = "Manual de Comandos", ChallengeId = 1, Description = "Beatriz precisa usar o comando cp para copiar um arquivo, mas ela não sabe como usá-lo corretamente. Ela decide consultar o manual do comando." },
                new Quest { Id = 4, Order = 4, Title = "Caminho Atual", ChallengeId = 1, Description = "Eduardo está navegando pelo sistema de arquivos e quer saber em qual diretório ele está atualmente." },
                new Quest { Id = 5, Order = 5, Title = "Movendo-se pelos Diretórios", ChallengeId = 1, Description = "Fernanda precisa entrar no diretório 'documentos' que está localizado dentro de seu diretório pessoal." },

                // Nível 2 Quests
                new Quest { Id = 6, Order = 1, Title = "Criando um Arquivo", ChallengeId = 2, Description = "Guilherme precisa criar um arquivo chamado 'novo_arquivo.txt' no diretório atual." },
                new Quest { Id = 7, Order = 2, Title = "Copiando um Arquivo", ChallengeId = 2, Description = "Helena precisa fazer uma cópia do arquivo 'documento.txt' e chamá-la de 'documento_backup.txt'." },
                new Quest { Id = 8, Order = 3, Title = "Movendo um Arquivo", ChallengeId = 2, Description = "Isabel quer mover o arquivo 'relatorio.txt' para o diretório 'relatorios'." },
                new Quest { Id = 9, Order = 4, Title = "Removendo um Arquivo", ChallengeId = 2, Description = "João precisa deletar o arquivo 'temp.txt' que está no diretório atual." },
                new Quest { Id = 10, Order = 5, Title = "Criando um Diretório", ChallengeId = 2, Description = "Karina precisa criar um diretório chamado 'projetos' em seu diretório pessoal." },

                // Nível 3 Quests
                new Quest { Id = 11, Order = 1, Title = "Alterando Permissões", ChallengeId = 3, Description = "Leonardo precisa dar permissão de leitura, escrita e execução ao dono do arquivo 'script.sh'." },
                new Quest { Id = 12, Order = 2, Title = "Mudando o Dono do Arquivo", ChallengeId = 3, Description = "Mariana precisa mudar o dono do arquivo 'dados.txt' para o usuário 'pedro'." },
                new Quest { Id = 13, Order = 3, Title = "Visualizando Processos em Execução", ChallengeId = 3, Description = "Nicolas quer ver uma lista de todos os processos que estão sendo executados no sistema." },
                new Quest { Id = 14, Order = 4, Title = "Matando um Processo", ChallengeId = 3, Description = "Olivia identificou que um processo está travando o sistema e precisa encerrá-lo. O PID do processo é 1234." },
                new Quest { Id = 15, Order = 5, Title = "Executando um Comando em Background", ChallengeId = 3, Description = "Pedro quer executar o comando backup.sh em segundo plano." },

                // Nível 4 Quests
                new Quest { Id = 16, Order = 1, Title = "Buscando por Arquivos", ChallengeId = 4, Description = "Ricardo precisa encontrar um arquivo chamado 'config.txt' em seu diretório pessoal." },
                new Quest { Id = 17, Order = 2, Title = "Buscando Texto em Arquivos", ChallengeId = 4, Description = "Sabrina quer encontrar todas as ocorrências da palavra 'erro' no arquivo 'log.txt'." },
                new Quest { Id = 18, Order = 3, Title = "Contando Linhas de um Arquivo", ChallengeId = 4, Description = "Thiago precisa saber quantas linhas o arquivo 'dados.csv' possui." },
                new Quest { Id = 19, Order = 4, Title = "Ordenando Linhas de um Arquivo", ChallengeId = 4, Description = "Vanessa quer ordenar as linhas do arquivo 'nomes.txt' em ordem alfabética." },
                new Quest { Id = 20, Order = 5, Title = "Eliminando Linhas Duplicadas", ChallengeId = 4, Description = "Wagner precisa remover as linhas duplicadas do arquivo 'lista.txt'." },

                // Nível 5 Quests
                new Quest { Id = 21, Order = 1, Title = "Compactando Arquivos", ChallengeId = 5, Description = "Xuxa precisa criar um arquivo compactado chamado 'backup.tar.gz' a partir do diretório 'projetos'." },
                new Quest { Id = 22, Order = 2, Title = "Descompactando Arquivos", ChallengeId = 5, Description = "Yuri recebeu um arquivo chamado 'dados.tar.gz' e precisa extrair seu conteúdo." },
                new Quest { Id = 23, Order = 3, Title = "Montando um Sistema de Arquivos", ChallengeId = 5, Description = "Zara precisa montar o sistema de arquivos localizado em '/dev/sdb1' no diretório '/mnt/usb'." },
                new Quest { Id = 24, Order = 4, Title = "Desmontando um Sistema de Arquivos", ChallengeId = 5, Description = "Amanda terminou de usar o sistema de arquivos montado em '/mnt/usb' e precisa desmontá-lo." },
                new Quest { Id = 25, Order = 5, Title = "Alterando o Dono de um Diretório Recursivamente", ChallengeId = 5, Description = "Bruno precisa mudar o dono do diretório 'projetos' e de todos os arquivos e subdiretórios para o usuário 'juliana'." },

                // Nível 6 Quests
                new Quest { Id = 26, Order = 1, Title = "Verificando Conexões de Rede", ChallengeId = 6, Description = "Carlos quer verificar as conexões de rede ativas em seu sistema." },
                new Quest { Id = 27, Order = 2, Title = "Pinging um Servidor", ChallengeId = 6, Description = "Daniela precisa verificar se consegue se conectar ao servidor 'example.com'." },
                new Quest { Id = 28, Order = 3, Title = "Configurando uma Interface de Rede", ChallengeId = 6, Description = "Eduardo precisa configurar a interface de rede 'eth0' com o endereço IP '192.168.1.100'." },
                new Quest { Id = 29, Order = 4, Title = "Adicionando uma Regra de Firewall", ChallengeId = 6, Description = "Fernanda precisa bloquear todo o tráfego de entrada na porta 80." },
                new Quest { Id = 30, Order = 5, Title = "Monitorando o Uso de Rede", ChallengeId = 6, Description = "Gabriel quer monitorar o uso de rede de sua interface 'wlan0'." }
            );

            // Seeds para Steps
            modelBuilder.Entity<Step>().HasData(
                // Nível 1 Steps
                new Step { Id = 1, Order = 1, Description = "", Command = "ls", ExpectedAnswer = "ls /home/ana", IsCompleted = false, QuestId = 1 },
                new Step { Id = 2, Order = 1, Description = "", Command = "cat", ExpectedAnswer = "cat mensagem.txt", IsCompleted = false, QuestId = 2 },
                new Step { Id = 3, Order = 1, Description = "", Command = "man", ExpectedAnswer = "man cp", IsCompleted = false, QuestId = 3 },
                new Step { Id = 4, Order = 1, Description = "", Command = "pwd", ExpectedAnswer = "pwd", IsCompleted = false, QuestId = 4 },
                new Step { Id = 5, Order = 1, Description = "", Command = "cd", ExpectedAnswer = "cd ~/documentos", IsCompleted = false, QuestId = 5 },

                // Nível 2 Steps
                new Step { Id = 6, Order = 1, Description = "", Command = "touch", ExpectedAnswer = "touch novo_arquivo.txt", IsCompleted = false, QuestId = 6 },
                new Step { Id = 7, Order = 1, Description = "", Command = "cp", ExpectedAnswer = "cp documento.txt documento_backup.txt", IsCompleted = false, QuestId = 7 },
                new Step { Id = 8, Order = 1, Description = "", Command = "mv", ExpectedAnswer = "mv relatorio.txt relatorios/", IsCompleted = false, QuestId = 8 },
                new Step { Id = 9, Order = 1, Description = "", Command = "rm", ExpectedAnswer = "rm temp.txt", IsCompleted = false, QuestId = 9 },
                new Step { Id = 10, Order = 1, Description = "", Command = "mkdir", ExpectedAnswer = "mkdir ~/projetos", IsCompleted = false, QuestId = 10 },

                // Nível 3 Steps
                new Step { Id = 11, Order = 1, Description = "", Command = "chmod", ExpectedAnswer = "chmod u+rwx script.sh", IsCompleted = false, QuestId = 11 },
                new Step { Id = 12, Order = 1, Description = "", Command = "chown", ExpectedAnswer = "sudo chown pedro dados.txt", IsCompleted = false, QuestId = 12 },
                new Step { Id = 13, Order = 1, Description = "", Command = "ps", ExpectedAnswer = "ps aux", IsCompleted = false, QuestId = 13 },
                new Step { Id = 14, Order = 1, Description = "", Command = "kill", ExpectedAnswer = "kill 1234", IsCompleted = false, QuestId = 14 },
                new Step { Id = 15, Order = 1, Description = "", Command = "./backup.sh &", ExpectedAnswer = "./backup.sh &", IsCompleted = false, QuestId = 15 },

                // Nível 4 Steps
                new Step { Id = 16, Order = 1, Description = "", Command = "find", ExpectedAnswer = "find ~/ -name config.txt", IsCompleted = false, QuestId = 16 },
                new Step { Id = 17, Order = 1, Description = "", Command = "grep", ExpectedAnswer = "grep 'erro' log.txt", IsCompleted = false, QuestId = 17 },
                new Step { Id = 18, Order = 1, Description = "", Command = "wc", ExpectedAnswer = "wc -l dados.csv", IsCompleted = false, QuestId = 18 },
                new Step { Id = 19, Order = 1, Description = "", Command = "sort", ExpectedAnswer = "sort nomes.txt", IsCompleted = false, QuestId = 19 },
                new Step { Id = 20, Order = 1, Description = "", Command = "uniq", ExpectedAnswer = "uniq lista.txt", IsCompleted = false, QuestId = 20 },

                // Nível 5 Steps
                new Step { Id = 21, Order = 1, Description = "", Command = "tar", ExpectedAnswer = "tar -czvf backup.tar.gz projetos/", IsCompleted = false, QuestId = 21 },
                new Step { Id = 22, Order = 1, Description = "", Command = "tar", ExpectedAnswer = "tar -xzvf dados.tar.gz", IsCompleted = false, QuestId = 22 },
                new Step { Id = 23, Order = 1, Description = "", Command = "mount", ExpectedAnswer = "sudo mount /dev/sdb1 /mnt/usb", IsCompleted = false, QuestId = 23 },
                new Step { Id = 24, Order = 1, Description = "", Command = "umount", ExpectedAnswer = "sudo umount /mnt/usb", IsCompleted = false, QuestId = 24 },
                new Step { Id = 25, Order = 1, Description = "", Command = "chown", ExpectedAnswer = "sudo chown -R juliana projetos/", IsCompleted = false, QuestId = 25 },

                // Nível 6 Steps
                new Step { Id = 26, Order = 1, Description = "", Command = "netstat", ExpectedAnswer = "netstat -tuln", IsCompleted = false, QuestId = 26 },
                new Step { Id = 27, Order = 1, Description = "", Command = "ping", ExpectedAnswer = "ping example.com", IsCompleted = false, QuestId = 27 },
                new Step { Id = 28, Order = 1, Description = "", Command = "ifconfig", ExpectedAnswer = "sudo ifconfig eth0 192.168.1.100", IsCompleted = false, QuestId = 28 },
                new Step { Id = 29, Order = 1, Description = "", Command = "iptables", ExpectedAnswer = "sudo iptables -A INPUT -p tcp --dport 80 -j DROP", IsCompleted = false, QuestId = 29 },
                new Step { Id = 30, Order = 1, Description = "", Command = "iftop", ExpectedAnswer = "sudo iftop -i wlan0", IsCompleted = false, QuestId = 30 }
            );

            // Seeds para Materials
            modelBuilder.Entity<Material>().HasData(
                // Nível 1 Materials
                new Material { Id = 1, Title = "Guia foca - Explicações básicas", Link = "https://www.guiafoca.org/guiaonline/iniciante/ch02s05.html", ChallengeId = 1 },
                new Material { Id = 2, Title = "Comandos Básicos do Linux", Link = "", ChallengeId = 1 },

                // Nível 2 Materials
                new Material { Id = 3, Title = "Manipulação de Arquivos no Linux", Link = "https://pt.wikibooks.org/wiki/Linux_Essencial/Li%C3%A7%C3%A3o_Manipula%C3%A7%C3%A3o_de_arquivos", ChallengeId = 2 },
                new Material { Id = 4, Title = "Entendendo Permissões no Linux", Link = "https://www.alura.com.br/artigos/entendendo-as-permissoes-no-linux", ChallengeId = 2 },

                // Nível 3 Materials
                new Material { Id = 5, Title = "Gerenciamento de Processos no Linux", Link = "https://www.hostinger.com.br/tutoriais/como-gerenciar-processos-no-linux-usando-linha-de-comando#:~:text=Para%20listar%20processos%20no%20Linux,processos%20por%20uso%20da%20CPU.", ChallengeId = 3 },
                new Material { Id = 6, Title = "Manipulando Permissões e Propriedades de Arquivos", Link = "https://www.alura.com.br/artigos/entendendo-as-permissoes-no-linux#:~:text=No%20Linux%2C%20conseguimos%20alterar%20a,diret%C3%B3rio%20e%20dos%20demais%20usu%C3%A1rios.", ChallengeId = 3 },

                // Nível 4 Materials
                new Material { Id = 7, Title = "Expressões Regulares no Linux", Link = "", ChallengeId = 4 },
                new Material { Id = 8, Title = "Comandos de Busca e Filtros no Linux", Link = "", ChallengeId = 4 },

                // Nível 5 Materials
                new Material { Id = 9, Title = "Manipulação Avançada de Arquivos e Diretórios", Link = "", ChallengeId = 5 },
                new Material { Id = 10, Title = "Compressão e Descompressão no Linux", Link = "", ChallengeId = 5 },

                // Nível 6 Materials
                new Material { Id = 11, Title = "Configuração de Rede no Linux", Link = "", ChallengeId = 6 },
                new Material { Id = 12, Title = "Monitoramento de Rede no Linux", Link = "", ChallengeId = 6 },
                new Material { Id = 13, Title = "Configuração de Firewall com iptables", Link = "", ChallengeId = 6 }
            );

            // Seeds para NecessaryKnowledges
            modelBuilder.Entity<NecessaryKnowledge>().HasData(
                // Nível 1 Knowledges
                new NecessaryKnowledge { Id = 1, Knowledge = "Navegação no sistema de arquivos", ChallengeId = 1 },
                new NecessaryKnowledge { Id = 2, Knowledge = "Listagem de diretórios e arquivos", ChallengeId = 1 },
                new NecessaryKnowledge { Id = 3, Knowledge = "Exibição do conteúdo de arquivos", ChallengeId = 1 },
                new NecessaryKnowledge { Id = 4, Knowledge = "Manual de comandos", ChallengeId = 1 },

                // Nível 2 Knowledges
                new NecessaryKnowledge { Id = 5, Knowledge = "Criação, cópia, movimentação e remoção de arquivos e diretórios", ChallengeId = 2 },
                new NecessaryKnowledge { Id = 6, Knowledge = "Conhecimento de caminhos absolutos e relativos", ChallengeId = 2 },
                new NecessaryKnowledge { Id = 7, Knowledge = "Permissões básicas de arquivos", ChallengeId = 2 },

                // Nível 3 Knowledges
                new NecessaryKnowledge { Id = 8, Knowledge = "Modificação de permissões e propriedades de arquivos", ChallengeId = 3 },
                new NecessaryKnowledge { Id = 9, Knowledge = "Gerenciamento básico de processos", ChallengeId = 3 },
                new NecessaryKnowledge { Id = 10, Knowledge = "Visualização de processos em execução", ChallengeId = 3 },

                // Nível 4 Knowledges
                new NecessaryKnowledge { Id = 11, Knowledge = "Uso de comandos de busca e filtros", ChallengeId = 4 },
                new NecessaryKnowledge { Id = 12, Knowledge = "Entendimento de expressões regulares básicas", ChallengeId = 4 },
                new NecessaryKnowledge { Id = 13, Knowledge = "Manipulação de fluxo de dados entre comandos", ChallengeId = 4 },

                // Nível 5 Knowledges
                new NecessaryKnowledge { Id = 14, Knowledge = "Manipulação avançada de arquivos e diretórios", ChallengeId = 5 },
                new NecessaryKnowledge { Id = 15, Knowledge = "Compressão e descompressão de arquivos", ChallengeId = 5 },
                new NecessaryKnowledge { Id = 16, Knowledge = "Montagem e desmontagem de sistemas de arquivos", ChallengeId = 5 },

                // Nível 6 Knowledges
                new NecessaryKnowledge { Id = 17, Knowledge = "Configuração básica de rede", ChallengeId = 6 },
                new NecessaryKnowledge { Id = 18, Knowledge = "Ferramentas de monitoramento de rede", ChallengeId = 6 },
                new NecessaryKnowledge { Id = 19, Knowledge = "Configurações de firewall", ChallengeId = 6 },
                new NecessaryKnowledge { Id = 20, Knowledge = "Noções de segurança e criptografia", ChallengeId = 6 }
            );
        }
    }
}
