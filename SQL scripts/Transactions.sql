BEGIN TRANSACTION;

BEGIN TRY

		DECLARE @cc INT;
		DECLARE @nome VARCHAR(60);
		DECLARE @tele INT;
		DECLARE @mail VARCHAR(60);
		DECLARE @rua VARCHAR(200);
		DECLARE @num_funcionario INT;
		DECLARE @username VARCHAR(50);
		DECLARE @password VARCHAR(50);
    
		-- Atribuir os valores dos parâmetros às variáveis
		SET @cc = @cartao;
		SET @nome = @nome_param;
		SET @tele = @tele_param;
		SET @mail = @mail_param;
		SET @rua = @rua_param;
		SET @num_funcionario = @nume_param;
		SET @username = @user_param;
		SET @password = @password_param;
    
		-- Inserir dados na tabela Pessoa
		INSERT INTO Otica_Pessoa (CC, nome, telemovel, email, morada)
		VALUES (@cc, @nome, @tele, @mail, @rua);

		-- Inserir dados na tabela Funcionario
		INSERT INTO Otica_Funcionario (CC)
		VALUES (@cc);

		-- Inserir dados na tabela Recepcionista
		INSERT INTO Otica_Recepcionista (CC, num_funcionario)
		VALUES (@cc, @num_funcionario);

		-- Inserir dados na tabela Login
		INSERT INTO Otica_Login (CC, username, password)
		VALUES (@cc, @username, @password);

		COMMIT;
		-- Todos os inserts foram bem-sucedidos, confirmar a transação
		
END TRY
BEGIN CATCH
    ROLLBACK;
    -- Ocorreu um erro em algum dos inserts, desfazer todas as alterações
END CATCH;


SELECT * FROM Otica_Pessoa
SELECT * FROM Otica_Cliente;
SELECT * FROM Otica_Consulta;
SELECT * FROM Otica_Vendido_Ao;



-- Verificar se há uma transação em andamento
IF @@TRANCOUNT > 0
BEGIN
    -- Desfazer a transação
    ROLLBACK TRANSACTION;
END