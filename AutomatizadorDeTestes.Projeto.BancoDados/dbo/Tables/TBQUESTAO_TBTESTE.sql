﻿CREATE TABLE [dbo].[TBQUESTAO_TBTESTE] (
    [QUESTAO_NUMERO] INT NOT NULL,
    [TESTE_NUMERO]   INT NOT NULL,
    CONSTRAINT [FK_TBQUESTAO_TBTESTE] FOREIGN KEY ([QUESTAO_NUMERO]) REFERENCES [dbo].[TBQUESTAO] ([NUMERO]),
    CONSTRAINT [FK_TBTESTE_TBQUESTAO] FOREIGN KEY ([TESTE_NUMERO]) REFERENCES [dbo].[TBTESTE] ([NUMERO])
);

