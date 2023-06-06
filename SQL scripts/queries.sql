use master; --use p2g2

--ver produtos de cada receita
SELECT Otica_Receita.id, Otica_Receita.descricao, Otica_Produto.id, Otica_Produto.nome
FROM Otica_Receita JOIN Otica_Produto ON Otica_Receita.produto_id = Otica_Produto.id;

--verificar informaçoes de receitas anteriores dos clientes
SELECT Otica_Cliente.CC, Otica_Pessoa.nome, Otica_Receita.id, Otica_Receita.descricao
FROM Otica_Cliente JOIN Otica_Pessoa ON Otica_Cliente.CC = Otica_Pessoa.CC JOIN Otica_Receita ON Otica_Cliente.CC = Otica_Receita.cliente_cc;

--ver todos os clientes com mais de 4 consultas
SELECT Otica_Cliente.CC, Otica_Cliente.nome, COUNT(Otica_Consulta.numero_consulta) AS num_consultas
FROM Otica_Cliente JOIN Otica_Consulta ON Otica_Cliente.CC = Otica_Consulta.cliente_cc
GROUP BY Otica_Cliente.CC, Otica_Cliente.nome
HAVING COUNT(Otica_Consulta.numero_consulta) > 4;

--ver todos os doutores com mais de 3 consultas num determinado dia
SELECT Otica_Doutor.CC, Otica_Doutor.nome, COUNT(Otica_Consulta.numero_consulta) AS num_consultas
FROM Otica_Doutor JOIN Otica_Consulta ON Otica_Doutor.CC = Otica_Consulta.cliente_cc WHERE Otica_Consulta.data_consulta = '2023-08-12'
GROUP BY Otica_Doutor.CC, Otica_Doutor.nome
HAVING COUNT(Otica_Consulta.numero_consulta) > 3;

--ver todos os produtos com mais de 10 em stock


--ver o fornecedor de cada produto


--ver o valor do pagamento de determinada fatura

