-- CLIENTE
-- LOGIN: teste.cliente@polaris.com
-- SENHA: 10102010

INSERT INTO polaris.login (LoginUuid, Usuario, Senha, Status)
VALUES ('aa1a8d20-6c97-4e3b-b13c-72f3e1ccc7d9', 'teste.cliente@polaris.com', 'otLSakDVyfGJRBcmprYSejZThIe35RVl4gPF0JLAR4Q=', '1');

INSERT INTO polaris.cliente (ClienteUuid, Cpf, Nome, Sobrenome, DataNascimento, Email, Telefone, Status, EnderecoId, LoginId)
VALUES ('3ff61193-e877-492b-98b8-a3a84080d92a', '57817580030', 'TESTE', 'TESTE', '2010-10-10', 'teste.cliente@polaris.com', '41998302815', '1', '65', (SELECT MAX(loginId) FROM polaris.login LIMIT 1));

-- GERENTE
-- LOGIN: gerente.teste@polaris.com
-- SENHA: 58408617000120

INSERT INTO polaris.login (LoginUuid, Usuario, Senha, Status)
VALUES ('22ed54b3-a14b-4e3a-b468-9c883d495b70', 'gerente.teste@polaris.com', '8myyHzAo3ZnOsLP6ENy+8tQSzkDR1EUkBcPaDJl6sMA=', '1');

INSERT INTO polaris.gerente (GerenteUuid, Cnpj, Empresa, Email, Telefone, Status, EnderecoId, LoginId)
VALUES ('39a3d2e6-ac3e-481a-a063-f98c5219c375', '58408617000120', 'GERENTE TESTE', 'gerente.teste@polaris.com', '41997524290', '1', '74', (SELECT MAX(loginId) FROM polaris.login LIMIT 1));
