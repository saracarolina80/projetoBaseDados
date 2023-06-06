-- INSERT VALUES --
use p9g5
-- Pessoa 
-- (CC, name, telemovel, email, morada )


-- PESSOAS
INSERT INTO Otica_Pessoa VALUES (123456789, 'Miguel Ferreira', 931231231, 'miguelf@ua.pt', 'Rua do azevinho')
INSERT INTO Otica_Pessoa VALUES (129872735, 'Maria Sousa', 961980010,'mariaS@gmail.com', 'Rua de Portugal')	
INSERT INTO Otica_Pessoa VALUES (133254674, 'Juliana Gomes' , 911980081, 'julianaG@gmail.com', 'Avenida Lourenco')		
INSERT INTO Otica_Pessoa VALUES (101543778, 'Catarina Martins', 931970011,'catarinaM@gmail.com', 'Rua Mouzinho')
INSERT INTO Otica_Pessoa VALUES (123218789, 'Diana Rosa', 964457219,'dianaR@gmail.com', 'Rua das Amoreiras')	
INSERT INTO Otica_Pessoa VALUES (134564245, 'Eduardo Fernades', 911965062 , 'eduardoF@gmail.com', 'Avenida Brasil')
INSERT INTO Otica_Pessoa VALUES (129399923, 'Mariana Felix', 963888910, 'felix@hotmail.pt', 'Rua Mario Sacramento')
INSERT INTO Otica_Pessoa VALUES (129469924, 'Helena Alves', 968293859, 'helena@ua.pt', 'Bairro do Liceu')
INSERT INTO Otica_Pessoa VALUES (129449925, 'Manuel Pires', 932991882, 'maneli@sapo.pt', 'Rua Oliveira da Serra')

INSERT INTO Otica_Pessoa VALUES (112231416, 'Diogo Gomes', 931231965 ,'diogoG@gmail.com', 'Rua dos Lagartos')
INSERT INTO Otica_Pessoa VALUES (144321435, 'Joao Pereira', 967827461,'joaoP@gmail.com', 'Rua Vitorino')	
INSERT INTO Otica_Pessoa VALUES (122312699, 'Sara Costa' , 934771882, 'sara@ua.pt', 'Rua Conde Areaes')
INSERT INTO Otica_Pessoa VALUES (190381839, 'Ines Oliveira', 935514263, 'ines@gmail.com', 'Travessa do Pescador')
INSERT INTO Otica_Pessoa VALUES (129491920, 'Fabio Gouveia', 933244155, 'fabio@sapo.pt', 'Rua da Gula')

INSERT INTO Otica_Pessoa VALUES (129495921, 'Lara Sousa', 965451245, 'lara@ua.pt', 'Avenida Boavista')
INSERT INTO Otica_Pessoa VALUES (129459922, 'Paulo Portas', 913277315, 'paulo@gmail.pt', 'Rua Abade')
	
INSERT INTO Otica_Funcionario VALUES (112231416);
INSERT INTO Otica_Funcionario VALUES (144321435);
INSERT INTO Otica_Funcionario VALUES (190381839);
INSERT INTO Otica_Funcionario VALUES (122312699);
INSERT INTO Otica_Funcionario VALUES (129491920);

-- DOUTORES 
INSERT INTO Otica_Funcionario VALUES (129495921);
INSERT INTO Otica_Funcionario VALUES (129459922);


INSERT INTO Otica_Recepcionista VALUES (112231416 , 111111111);
INSERT INTO Otica_Recepcionista VALUES (144321435 , 222222222);
INSERT INTO Otica_Recepcionista VALUES (190381839 , 333333333);
INSERT INTO Otica_Recepcionista VALUES (122312699 , 444444444);
INSERT INTO Otica_Recepcionista VALUES (129491920 , 555555555);

INSERT INTO Otica_Cliente VALUES (123456789, 247713243, 112231416)
INSERT INTO Otica_Cliente VALUES (129872735, 244818274, 112231416)
INSERT INTO Otica_Cliente VALUES (133254674, 243274859, 112231416)
INSERT INTO Otica_Cliente VALUES (101543778, 245612541, 112231416)
INSERT INTO Otica_Cliente VALUES (123218789, 244219428, 112231416)
INSERT INTO Otica_Cliente VALUES (134564245, 164601890, 112231416)
INSERT INTO Otica_Cliente VALUES (129399923, 164601891, 112231416)
INSERT INTO Otica_Cliente VALUES (129469924, 245671892, 112231416)
INSERT INTO Otica_Cliente VALUES (129449925, 246817189, 112231416)





-- CREDENCIAIS
INSERT INTO Otica_Login VALUES (112231416 , 'funcionario1' , 'otica1');
INSERT INTO Otica_Login VALUES (144321435 , 'funcionario2' , 'otica2');
INSERT INTO Otica_Login VALUES (190381839 , 'funcionario3' , 'otica3');
INSERT INTO Otica_Login VALUES (122312699 , 'funcionario4' , 'otica4');
INSERT INTO Otica_Login VALUES (129491920 , 'funcionario5' , 'otica5');

INSERT INTO Otica_Doutor VALUES (129495921 , 100110011);
INSERT INTO Otica_Doutor VALUES (129459922 , 249111111);


-- INSERIR PRODUTOS ---
INSERT INTO Otica_Produto VALUES (1,'120', 'Lentes contacto', 'Police' , 'lentes1')
INSERT INTO Otica_Produto VALUES (2,'96', 'Lentes Progessivas', 'Ana Hittman' , 'lentesP')
INSERT INTO Otica_Produto VALUES (3,'137', 'oculos graduados', 'Police' , 'oculos graduados1')
INSERT INTO Otica_Produto VALUES (4,'72', 'oculos de sol', 'Rayban' , 'oculos de sol1')



-- OTICA_STOCK
INSERT INTO Otica_Stock VALUES (1, 1, '2023-05-01', 'Em stock', 50);
INSERT INTO Otica_Stock VALUES (2, 2, '2023-05-02', 'Em stock', 30);
INSERT INTO Otica_Stock VALUES (3, 3, '2023-05-03', 'Em stock', 20);
INSERT INTO Otica_Stock VALUES (4, 4, '2023-05-04', 'Em stock', 40);

-- OTICA_FORNECEDOR
INSERT INTO Otica_Fornecedor VALUES ('123456789', 'Fornecedor A', '912345678', 'fornecedorA@gmail.com', 'Rua do Fornecedor, 123');
INSERT INTO Otica_Fornecedor VALUES ('987654321', 'Fornecedor B', '923456789', 'fornecedorB@gmail.com', 'Rua do Fornecedor, 456');

-- OTICA_VENDIDO_AO
INSERT INTO Otica_Vendido_Ao VALUES (123456789, 1, 2);
INSERT INTO Otica_Vendido_Ao VALUES (129872735, 2, 1);
INSERT INTO Otica_Vendido_Ao VALUES (133254674, 3, 3);
INSERT INTO Otica_Vendido_Ao VALUES (101543778, 4, 2);

-- OTICA_FORNECIDO_POR
INSERT INTO Otica_Fornecido_Por VALUES (1, '123456789');
INSERT INTO Otica_Fornecido_Por VALUES (2, '123456789');
INSERT INTO Otica_Fornecido_Por VALUES (3, '987654321');
INSERT INTO Otica_Fornecido_Por VALUES (4, '987654321');

-- OTICA_RECEITA
INSERT INTO Otica_Receita VALUES (1, 'Receita para lentes de contacto', 129495921, 123456789, 1);
INSERT INTO Otica_Receita VALUES (2, 'Receita para óculos graduados', 129459922, 129872735, 3);

-- OTICA_FATURA
INSERT INTO Otica_Fatura VALUES (1, 'Fatura de venda de óculos', 23, 120.00, 123456789);
INSERT INTO Otica_Fatura VALUES (2, 'Fatura de venda de lentes', 23, 50.00, 129872735);

-- OTICA_PAGAMENTO
INSERT INTO Otica_Pagamento VALUES (1, '2023-05-05', 120.00, 'Cartão de crédito', 'Comprovativo1.jpg', 123456789, 1);
INSERT INTO Otica_Pagamento VALUES (2, '2023-05-06', 50.00, 'Dinheiro', 'Comprovativo2.jpg', 129872735, 2);


SELECT * FROM Otica_Pessoa;
SELECT * FROM Otica_Cliente;
-- SELECT * FROM Otica_Produto;
SELECT * FROM Otica_Funcionario;
SELECT * FROM Otica_Doutor;
SELECT * FROM Otica_Recepcionista;
SELECT * FROM Otica_Login;