GO
CREATE FUNCTION IsProductInStock ( 
	@ProdutoID INT 
)
RETURNS BIT 
AS
BEGIN
    DECLARE @Disponibilidade BIT

    IF EXISTS (
        SELECT 1
        FROM Otica_Stock
        WHERE produto_id = @ProdutoID AND estado = 'Em stock' AND quantidade > 0
    )
        SET @Disponibilidade = 1
    ELSE
        SET @Disponibilidade = 0

    RETURN @Disponibilidade
END;


CREATE FUNCTION CalculateTotalSales (@cliente_cc INT)
RETURNS FLOAT
AS
BEGIN
  DECLARE @TotalSales FLOAT;
  SELECT @TotalSales = SUM(p.preço * va.n_produtos)
  FROM Otica_Vendido_Ao va
  INNER JOIN Otica_Produto p ON va.produto_id = p.id
  WHERE va.cliente_cc = @cliente_cc;
  RETURN @TotalSales;
END
.



CREATE FUNCTION GetTotalProductsSuppliedBySupplier (@fornecedor_nif VARCHAR(20))
RETURNS INT
AS
BEGIN
  DECLARE @TotalProducts INT;
  SELECT @TotalProducts = SUM(s.quantidade)
  FROM Otica_Stock AS s
  INNER JOIN Otica_Fornecido_Por AS fp ON s.produto_id = fp.produto_id
  INNER JOIN Otica_Fornecedor AS f ON fp.fornecedor_nif = f.nif
  WHERE f.nif = @fornecedor_nif AND s.estado = 'Em stock';
  RETURN @TotalProducts;
END

CREATE FUNCTION dbo.GetNomeRecepcionista (@Username VARCHAR(50))
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @NomeRecepcionista VARCHAR(100);

    SELECT @NomeRecepcionista = Otica_Pessoa.nome
    FROM Otica_Pessoa
    INNER JOIN Otica_Funcionario ON Otica_Pessoa.CC = Otica_Funcionario.CC
    INNER JOIN Otica_Recepcionista ON Otica_Funcionario.CC = Otica_Recepcionista.CC
    INNER JOIN Otica_Login ON Otica_Recepcionista.CC = Otica_Login.CC
    WHERE Otica_Login.username = @Username;

    RETURN @NomeRecepcionista;
END;