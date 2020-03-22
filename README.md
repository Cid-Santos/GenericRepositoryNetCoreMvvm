# GenericRepositoryNetCoreMvvm

## Introdução

Nesta sessão, aprenderemos sobre:
Repositório genérico para SQLite em .Net Core com estrutura MVVM.

#### Repositório Genérico:
A vantagem do repositório genérico esta no padrão do repositório que cria uma camada abstrata entre a Camada de Acesso a Dados e a Camada de Serviço de um aplicativo. Um Repositório Genérico é composto por classes, interfaces ou métodos que possuem valores de espaço reservado para o parâmetro de tipo de dados a ser utilizados, em vez de especificá-lo implicitamente.

#### Programação Assíncrona:
A programação assíncrona é uma técnica de programação paralela, que permite que os Processos sejam executados separadamente da thread principal do aplicativo. Assim que o trabalho é concluído, ele informa o tópico principal sobre o resultado, se foi bem-sucedido ou não.

#### Modulo I/O SQLite Assíncrono:
O SQLite é um banco de dados eficiente oferecendo uma interface SQL para processar consultas de dados relacionais na memória ou persistir em um arquivo de forma simples e portátil. Seu design leve o torna um candidato ideal para um banco de dados incorporado em aplicativos portáteis (CLI). 

*Normalmente, quando o SQLite grava em um arquivo de banco de dados, ele espera até que a operação de gravação seja concluída antes de retornar o controle ao aplicativo de chamada.*

O I/O Assíncrono é uma extensão que faz com que o SQLite execute todas as solicitações de gravação em disco *(algumas vezes lenta)* usando um thread em segundo plano. Embora isso não reduza os recursos do sistema, permite que o SQLite retorne o controle rapidamente ao chamador, mesmo que esteja ocorrendo em seu ritmo *(algumas vezes lento)*  em segundo plano.

## Pré requisitos

Para poder executar o exemplo a partir do download ou compilá-lo do zero, você precisa das seguintes ferramentas,

Visual Studio 2019 ou superior 
.NET Core 3.1.102 ou superior

A vantagem do repositório genérico é que você pode herdar dele, passar um tipo de entidade e terá operações CRUD.


continua...
