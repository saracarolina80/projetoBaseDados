CREATE TABLE Otica_Pessoa (
  CC                INT CHECK (CC >= 100000000 AND CC <= 999999999) PRIMARY KEY,
  nome              VARCHAR(60),
  telemovel         INT CHECK (telemovel >= 100000000 AND telemovel <= 999999999),
  email             VARCHAR(60),
  morada            VARCHAR(200)
);

CREATE TABLE Otica_Funcionario (
  CC                INT CHECK (CC >= 100000000 AND CC <= 999999999) PRIMARY KEY,
  FOREIGN KEY (CC) REFERENCES Otica_Pessoa(CC)
);

CREATE TABLE Otica_Doutor (
  CC                 INT CHECK (CC >= 100000000 AND CC <= 999999999) PRIMARY KEY,
  num_SNS            INT CHECK (num_SNS >= 100000000 AND num_SNS <= 999999999),
  FOREIGN KEY (CC) REFERENCES Otica_Funcionario(CC)
);

CREATE TABLE Otica_Recepcionista (
  CC                 INT CHECK (CC >= 100000000 AND CC <= 999999999) PRIMARY KEY,
  num_funcionario    INT CHECK (num_funcionario >= 100000000 AND num_funcionario <= 999999999),
  FOREIGN KEY (CC) REFERENCES Otica_Funcionario(CC)
);

CREATE TABLE Otica_Cliente (
  CC INT PRIMARY KEY,
  num_contribuinte INT CHECK (num_contribuinte >= 100000000 AND num_contribuinte <= 999999999),
  
  FOREIGN KEY (CC) REFERENCES Otica_Pessoa(CC),
);

CREATE TABLE Otica_Produto (
  id VARCHAR(20) PRIMARY KEY,
  preço VARCHAR(100),
  tipo VARCHAR(100),
  marca VARCHAR(50),
  nome  VARCHAR(100),
);

CREATE TABLE Otica_Stock (
  id            INT PRIMARY KEY,
  produto_id    VARCHAR(20),
  data_entrada  DATE,
  estado        VARCHAR(50),
  quantidade    INT,
  FOREIGN KEY (produto_id) REFERENCES Otica_Produto(id)
);

CREATE TABLE Otica_Fornecedor (
  nif         VARCHAR(20) PRIMARY KEY,
  nome        VARCHAR(100),
  telemovel   VARCHAR(20),
  email       VARCHAR(100),
  morada      VARCHAR(200)
);

CREATE TABLE Otica_Vendido_Ao (
  cliente_cc INT,
  produto_id VARCHAR(20),
  n_produtos INT,
  FOREIGN KEY (cliente_cc) REFERENCES Otica_Cliente(CC),
  FOREIGN KEY (produto_id) REFERENCES Otica_Produto(id),
  PRIMARY KEY (cliente_cc, produto_id)
);

CREATE TABLE Otica_Fornecido_Por (
  produto_id        VARCHAR(20),
  fornecedor_nif    VARCHAR(20),
  FOREIGN KEY (produto_id) REFERENCES Otica_Produto(id),
  FOREIGN KEY (fornecedor_nif) REFERENCES Otica_Fornecedor(nif),
  PRIMARY KEY (produto_id, fornecedor_nif)  
);

CREATE TABLE Otica_Consulta (
  numero_consulta INT PRIMARY KEY,
  hora TIME,
  preço DECIMAL(10, 2),
  data_consulta DATE,
  recepcionista_cc INT,
  doutor_cc INT,
  cliente_cc INT,
  FOREIGN KEY (recepcionista_cc) REFERENCES Otica_Recepcionista(CC),
  FOREIGN KEY (doutor_cc) REFERENCES Otica_Doutor(CC),
  FOREIGN KEY (cliente_cc) REFERENCES Otica_Cliente(CC)
);

CREATE TABLE Otica_Receita (
  id INT PRIMARY KEY,
  descricao VARCHAR(200),
  doutor_cc INT,
  cliente_cc INT,
  produto_id VARCHAR(20),
  FOREIGN KEY (doutor_cc) REFERENCES Otica_Doutor(CC),
  FOREIGN KEY (cliente_cc) REFERENCES Otica_Cliente(CC),
  FOREIGN KEY (produto_id) REFERENCES Otica_Produto(id)
);

CREATE TABLE Otica_Fatura (
  id INT PRIMARY KEY,
  descriçao VARCHAR(200),
  iva INT,
  preco DECIMAL(10, 2),
  cliente_cc INT,
  FOREIGN KEY (cliente_cc) REFERENCES Otica_Cliente(CC)
);

CREATE TABLE Otica_Pagamento (
  id INT PRIMARY KEY,
  data DATE,
  valor DECIMAL(10, 2),
  metodo VARCHAR(50),
  comprovativo VARCHAR(200),
  cliente_cc INT,
  fatura_id INT,
  FOREIGN KEY (cliente_cc) REFERENCES Otica_Cliente(CC),
  FOREIGN KEY (fatura_id) REFERENCES Otica_Fatura(id)
);

CREATE TABLE Otica_Login (
  CC                 INT CHECK (CC >= 100000000 AND CC <= 999999999) PRIMARY KEY,
  username        VARCHAR(50) NOT NULL,
  password        VARCHAR(50) NOT NULL,
  FOREIGN KEY (CC) REFERENCES Otica_Recepcionista(CC)
);
