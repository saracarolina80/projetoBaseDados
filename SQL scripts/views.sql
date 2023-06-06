

CREATE VIEW ConsultasPorCliente AS
SELECT Otica_Cliente.CC, Otica_Cliente.nome, COUNT(Otica_Consulta.numero_consulta) AS total_consultas
FROM Otica_Cliente
JOIN Otica_Consulta ON Otica_Cliente.CC = Otica_Consulta.cliente_cc
GROUP BY Otica_Cliente.CC, Otica_Cliente.nome;

CREATE VIEW DoutoresConsultas AS
SELECT Otica_Doutor.CC, Otica_Doutor.num_SNS, COUNT(Otica_Consulta.numero_consulta) AS total_consultas
FROM Otica_Doutor
JOIN Otica_Consulta ON Otica_Doutor.CC = Otica_Consulta.doutor_cc
GROUP BY Otica_Doutor.CC, Otica_Doutor.num_SNS;


CREATE VIEW StockProdutos AS
SELECT Otica_Produto.id, Otica_Produto.nome, Otica_Stock.quantidade
FROM Otica_Produto
JOIN Otica_Stock ON Otica_Produto.id = Otica_Stock.produto_id;
