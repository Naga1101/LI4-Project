USE [JBLeiloes]

INSERT INTO [dbo].[Utilizador] ([username], [password], [nome], [email], [CC], [NIF], [data_nascimento], [tipo_utilizador])
VALUES
    ('Rui', 'rui', 'Rui Cerqueira', 'rui@gmail.com', 123456789, 987654321, '1990-01-01', 1),
    ('Nuno', 'nuno', 'Nuno Aguiar', 'nuno@gmail.com', 987654321, 123456789, '1985-05-15', 1),
    ('TomasC', 'tomas', 'Tomas Cunha', 'tomascunha@gmail.com', 555555555, 111111111, '1995-08-22', 1),
    ('Gui', 'gui', 'Guilherme Rio', 'gui@gmail.com', 222222222, 444444444, '1980-12-10', 2),
    ('TomasV', 'tomas', 'Tomas Valente', 'tomasvalente@gmail.com', 888888888, 333333333, '1992-04-30', 2),
    ('Admin', 'admin', 'admin', 'admin@jbleiloes.com', 111111111, 555555555, '1988-07-18', 0);

INSERT INTO [dbo].[Veiculo] ([Marca], [Modelo], [Ano], [Quilometragem], [DUA], [Seguro], [dono])
VALUES
    ('Aston Martin', 'Valour', 2003, 35000.00, 'ABC123', 'InsuranceCo1', 'Rui'),
    ('BMW', '507', 1990, 28000.00, 'XYZ456', 'InsuranceCo2', 'Nuno'),
    ('Bugatti', 'Type 64', 1960, 400.00, 'DEF789', 'InsuranceCo3', 'Nuno'),
    ('Bugatti', 'Chiron', 2019, 25000.00, 'GHI101', 'InsuranceCo4', 'Gui'),
    ('Ferrari', 'Enzo', 2016, 45000.80, 'JKL111', 'InsuranceCo5', 'Gui'),
    ('Ferrari', 'F40', 2015, 50000.00, 'MNO222', 'InsuranceCo6', 'TomasV'),
	('Horch', 'AG', 1990, 50000.00, 'MNO222', 'InsuranceCo6', 'Rui'),
	('Koenigsegg', 'Regera', 1990, 50000.00, 'MNO222', 'InsuranceCo6', 'TomasC'),
	('Ferrari', 'la Ferrari', 1990, 50000.00, 'MNO222', 'InsuranceCo6', 'TomasC'),
	('Koenigsegg', 'Gemera', 2018, 100.00, 'MNO222', 'InsuranceCo6', 'Rui'),
	('Ferrari', 'Spyder', 1990, 50000.00, 'MNO222', 'InsuranceCo6', 'TomasV'),
	('Maserati', 'MC20', 2010, 50000.00, 'MNO222', 'InsuranceCo6', 'TomasC'),
	('Mercedes', '770k', 2010, 50000.00, 'MNO222', 'InsuranceCo6', 'Nuno'),
	('Lamborghini', 'Huracan', 2020, 100.00, 'MNO222', 'InsuranceCo6', 'Rui');

INSERT INTO [dbo].[Leilao] ([titulo], [valor_inicial], [vendedor], [valor_minimo], [valor_atual], [veiculo], [aprovado], [a_decorrer], [comprador], [tempo_de_leilao], [imagem], [Pago])
VALUES
    ('Aston Martin Valour', 1000.00, 'Rui', 5000.00, 40000, 1, 1, 0, 'Nuno', '2024-01-22 04:30:00', 'as1.jpg|as2.jpg|as3.jpg', 1),
    ('BMW 507', 25000.00, 'Nuno', 50000, 0, 2, 1, 1, NULL, '2024-02-21 02:15:00', 'bm5071.jpg|bm5072.jpg|bm5073.jpg', 0),
    ('Bugatti Type 64', 100000.00, 'Nuno', 50000.00, 0, 3, 1, 1, NULL, '2024-02-28 03:00:00', 'bu1.jpg|bu2.jpg|bu3.jpg', 0),
    ('Bugatti Chiron', 105000.00, 'Gui', 100000.00, 0, 4, 1, 1, NULL, '2024-02-25 01:45:00', 'chiron1.jpg|chiron2.jpg|chiron3.jpg', 0),
    ('Ferrari Enzo', 30000.00, 'Gui', 10000.00, 0, 5, 1, 1, NULL, '2024-02-23 02:30:00', 'enzo1.jpg|enzo2.jpg|enzo3.jpg', 0),
    ('Ferrari F40', 40000.00, 'TomasV', 10000.00, 0, 6, 1, 1, NULL, '2024-02-21 05:00:00', 'f401.jpg|f402.jpg|f403.jpg', 0),
	('Horch AG', 50000.00, 'Rui', 25000.00, 0, 7, 1, 1, NULL, '2024-02-23 02:30:00', 'Horch1.jpg|Horch2.jpg|Horch3.jpg', 0),
	('Koenigsegg Regera', 150000.00, 'TomasC', 50000.00, 0, 8, 1, 1, NULL, '2024-02-23 02:30:00', 'k1.jpg|k2.jpg|k3.jpg', 0),
	('Koenigsegg Gemera', 200000.00, 'Rui', 50000.00, 0, 10, 1, 1, NULL, '2024-02-23 02:30:00', 'gm1.jpg|gm2.jpg|gm3.jpg', 0),
	('Ferrari la Ferrari', 200000.00, 'TomasC', 50000.00, 0, 9, 1, 1, NULL, '2024-02-23 02:30:00', 'lf1.jpg|lf2.jpg|lf3.jpg', 0),
	('Ferrari Spyder', 500000.00, 'TomasV', 10000.00, 0, 11, 1, 1, NULL, '2024-02-23 02:30:00', 'spyder1.jpg|spyder2.jpg|spyder3.jpg', 0),
	('Maserati MC20', 300000.00, 'TomasC', 10000.00, 0, 12, 1, 1, NULL, '2024-02-23 02:30:00', 'mas1.jpg|mas2.jpg|mas3.jpg', 0),
	('Mercedes 770k', 100000.00, 'Nuno', 10000.00, 0, 13, 1, 1, NULL, '2024-02-23 02:30:00', 'mbenz770k1.jpg|mbenz770k2.jpg|mbenz770k3.jpg', 0),
	('Lamborghini Huracan', 250000.00, 'Rui', 10000.00, 0, 14, 1, 1, NULL, '2024-02-23 02:30:00', 'tiagovski1.jpg|tiagovski2.jpg|tiagovski3.jpg', 0);


-- INSERIR DEPOIS
SELECT * FROM Leilao

INSERT INTO [dbo].[Licitacao] (id_licitador, valor_licitacao, id_leilao)
VALUES 
	('Tomasc', 10000, 1),
	('Nuno', 40000, 1);

INSERT INTO [dbo].[Historico de compras] (cliente, id_leilao)
	VALUES ('Nuno', 1);

INSERT INTO [dbo].[Historico de vendas] (cliente, id_leilao)
	VALUES ('Rui', 1);

SELECT * FROM Leilao