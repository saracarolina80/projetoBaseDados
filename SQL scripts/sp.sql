CREATE PROCEDURE InserirCliente
  @CC INT,
  @nome VARCHAR(60),
  @telemovel INT,
  @email VARCHAR(60),
  @morada VARCHAR(200),
  @num_contribuinte INT,
  @funcionario_cc INT
AS
BEGIN
  INSERT INTO Otica_Pessoa (CC, nome, telemovel, email, morada)
  VALUES (@CC, @nome, @telemovel, @email, @morada);

  INSERT INTO Otica_Cliente (CC, num_contribuinte, funcionario_cc)
  VALUES (@CC, @num_contribuinte, @funcionario_cc);
END

CREATE PROCEDURE RemoverCliente
  @CC INT
AS
BEGIN
  DELETE FROM Otica_Cliente WHERE CC = @CC;
  DELETE FROM Otica_Pessoa WHERE CC = @CC;
END


CREATE PROCEDURE AgendarConsulta
  @numero_consulta INT,
  @hora TIME,
  @preço DECIMAL(10, 2),
  @data_consulta DATE,
  @recepcionista_cc INT,
  @doutor_cc INT,
  @cliente_cc INT
AS
BEGIN
  INSERT INTO Otica_Consulta (numero_consulta, hora, preço, data_consulta, recepcionista_cc, doutor_cc, cliente_cc)
  VALUES (@numero_consulta, @hora, @preço, @data_consulta, @recepcionista_cc, @doutor_cc, @cliente_cc);
END


CREATE PROCEDURE RegistarVendaProduto
  @cliente_cc INT,
  @produto_id INT,
  @n_produtos INT
AS
BEGIN
  INSERT INTO Otica_Vendido_Ao (cliente_cc, produto_id, n_produtos)
  VALUES (@cliente_cc, @produto_id, @n_produtos);

  UPDATE Otica_Stock
  SET quantidade = quantidade - @n_produtos
  WHERE produto_id = @produto_id;
END


CREATE PROCEDURE RegistarEntregaProduto
  @id INT,
  @data_entrada DATE,
  @estado VARCHAR(50),
  @quantidade INT,
  @produto_id INT
AS
BEGIN
  INSERT INTO Otica_Stock (id, produto_id, data_entrada, estado, quantidade)
  VALUES (@id, @produto_id, @data_entrada, @estado, @quantidade);
END


CREATE PROCEDURE RegistarPagamentoFatura
  @id INT,
  @data DATE,
  @valor DECIMAL(10, 2),
  @metodo VARCHAR(50),
  @comprovativo VARCHAR(200),
  @cliente_cc INT,
  @fatura_id INT
AS
BEGIN
  INSERT INTO Otica_Pagamento (id, data, valor, metodo, comprovativo, cliente_cc, fatura_id)
  VALUES (@id, @data, @valor, @metodo, @comprovativo, @cliente_cc, @fatura_id);
END


DROP PROCEDURE getClientebyCC;
GO
CREATE PROCEDURE getClientebyCC
    @CC INT
AS
BEGIN
    SELECT Otica_Pessoa.CC, Otica_Pessoa.nome, Otica_Pessoa.email, Otica_Pessoa.telemovel, Otica_Pessoa.morada, Otica_Cliente.num_contribuinte 
	FROM Otica_Pessoa JOIN Otica_Cliente ON Otica_Pessoa.CC = Otica_Cliente.CC

    WHERE Otica_Pessoa.CC = @CC;
END;


CREATE PROCEDURE AtualizarCliente
    @CC INT,
    @NovoNome VARCHAR(50),
    @NovoEmail VARCHAR(60),
	@NovoMorada VARCHAR(200),
	@NovoTelemovel INT,
	@NovoNum_Contribuinte INT
AS
BEGIN
    UPDATE Otica_Pessoa
    SET nome = @NovoNome, email = @NovoEmail, morada = @NovoMorada , telemovel = @NovoTelemovel
    WHERE CC = @CC
	UPDATE Otica_Cliente
	SET num_contribuinte = @NovoNum_Contribuinte 
	WHERE CC = @CC
END;


