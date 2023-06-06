Sistema de Gestão de uma Ótica
===============


## Projeto de Base de Dados LECI Grupo p9g5
### - Sara Gonçalves 98376
### - Pedro Santos 98158


## Introdução
No âmbito da cadeira de Base de Dados, o projeto que iremos desenvolver é um Sistema de Gestão de uma Ótica.
A primeira parte foca-se na realização da análise de requisitos, no diagrama de Entidade-Relacionamento e o seu mapeamento para o Esquema Relacional.

## Análise de Requisitos
A gestão de uma ótica é bastante importante para o seu sucesso, tanto de forma lucrativa como de organização, pois isso envolve, por exemplo, a seleção cuidadosa dos produtos necessários aos clientes, a manutenção de uma loja "agradável", com funcionários profissionais, entre outras coisas.

A base de dados que irá ser desenvolvida permitirá guardar todos os dados necessários de um cliente, dos produtos disponíveis em loja, produtos que foram pedidos ao fabricante, vendas, pagamentos, consultas, etc.

Assim, os utilizadores deste sistema (funcionários da ótica que tiverem autorização) deverão conseguir:
- Inserir/Remover clientes no registo de clientes da ótica;
- Inserir/Remover informação de determinado cliente;
- Agendar consultas com a data e hora;
- Atribuir a consulta a um Doutor;
- Verificar se determinado produto encontra-se em loja;
- Verificar pedidos ao fabricante;
- Registar produtos novos no sistema e adicionar informações como tipo, marca, preço e quantidade em stock;
- Atualizar informações de produtos existentes, como preço, marca ou quantidade em stock;
- Verificar o stock de um produto específico;
- Gerir as encomendas a fornecedores, incluindo fazer pedidos de novos produtos e registar entregas de produtos;
- Registar informações de pagamento de clientes, incluindo consultas e produtos comprados;
- Gerir o calendário dos Doutores, permitindo que os recepcionistas agendem consultas em horários disponíveis;
- Verificar informações de receitas anteriores de um cliente;

### Entidades e Atributos
```
-> Funcionário
é uma pessoa que trabalha na ótica e é caracterizado por um número de CC (PK), nome , telemóvel, morada e email.

O funcionário pode ser Recepcionista ou Doutor.
Os Recepcionistas são caracterizados pelo número de funcionário (num_func) e são responsáveis por marcar consultas e por vender os produtos aos clientes. Os Doutores são caracterizados pelo número de SNS e são responsáveis por realizar as consultas.    

-> Cliente
é uma pessoa que compra produtos ou "vai" às consultas e é caracterizado por um número de CC, nome, morada, telemóvel, email e NIF(PK).

-> Fornecedor
é uma pessoa que fornece os produtos pedidos e é caracterizado por NIF (PK), um nome, morada, telemóvel, email. 

-> Produto
é o produto que está em loja ou que poderá ser pedido ao fornecedor e é caracterizado pelo tipo de produto, marca, preço, quantidade, nome e ID do produto (PK).

-> Consulta
é uma consulta marcada pelo Recepcionista, realizada pelo Doutor para o Cliente. É caracterizada pelo número da consulta (PK), data, hora, preço, CC do cliente, CC do doutor.

-> Receita
é uma receita passada pelo Doutor depois da consulta. É caracterizada pelo ID da receita(PK), descrição, NIF do clientes (FK), CC do doutor (FK) e NIF do fornecedor (FK).

-> Pagamento
é o pagamento do produto ou da consulta. É caracterizado pelo Valor, método de pagamento, data de pagamento, comprovativo (PK), NIF do cliente (FK) e ID do produto (FK).

-> Fatura
é o documento fiscal que é emitido para o cliente após uma compra. É caracterizado pelo ID da fatura(PK), pela descrição do produto, impostos, preço total e comprovativo (FK).

-> Stock
representa a quantidade de cada produto disponível em loja num determinado momento. é caracterizado pelo ID do stock (PK), pelo ID do produto(FK), quantidade, data de entrada, data de saída, e o estado (se está em stock ou não).

```
### Relações
```
- Relação Produto - Cliente: N : M
    "O produto é vendido ao Cliente"
    atributos da relação: nº de produtos

- Relação Produto - Fornecedor: N : M
    "O produto é fornecido pelo Fornecedor"

- Relação Consulta - Doutor: N : 1
    "A consulta é realizada por 1 Doutor"

- Relação Consulta - Recepcionista: N : 1
    "A consulta é agendada por 1 Recepcionista"

- Relação Consulta - Cliente: N : 1
    "O cliente vai à consulta"

- Relação Recepcionista - Cliente: 1 : N
    "O recepcionista regista os clientes"

- Relação Receita - Fornecedor: N : 1
    "A receita é enviada para o Fornecedor"

- Relação Receita - Doutor: N : 1
    "A receita é passada pelo Doutor"

- Relação Pagamento - Cliente: N : 1
    "O pagamento é realizado pelo Cliente"

- Relação Pagamento - Fatura: N : 1
    "Fatura pode ter associados vários pagamentos (por exemplo se a compra for paga em prestações)"

- Relação entre Stock - Produto: 1 : N
    "O stock pode ter vários produtos"

- Relação entre Fatura - Cliente: N : 1
    "A fatura é emitida para o Cliente"

```

## Diagrama Entidade-Relacionamento

![diagrama entidade-relacionamento!](diagrama.png)

## Esquema Relacional
![esquema relacional!](esquema.png)
 