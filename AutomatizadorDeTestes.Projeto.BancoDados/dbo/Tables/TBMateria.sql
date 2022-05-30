CREATE TABLE [dbo].[TBMateria] (
    [Numero]            INT           IDENTITY (1, 1) NOT NULL,
    [Nome]              VARCHAR (300) NOT NULL,
    [Serie]             INT           NOT NULL,
    [Disciplina_Numero] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Numero] ASC),
    CONSTRAINT [FK_TBMateria] FOREIGN KEY ([Disciplina_Numero]) REFERENCES [dbo].[TBDisciplina] ([Numero])
);

