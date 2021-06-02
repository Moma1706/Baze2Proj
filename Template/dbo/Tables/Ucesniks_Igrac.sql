CREATE TABLE [dbo].[Ucesniks_Igrac] (
    [Pozicija]   NVARCHAR (MAX) NOT NULL,
    [BrojGolova] INT            NOT NULL,
    [Visina]     INT            NOT NULL,
    [JMBG]       BIGINT         NOT NULL,
    CONSTRAINT [PK_Ucesniks_Igrac] PRIMARY KEY CLUSTERED ([JMBG] ASC),
    CONSTRAINT [FK_Igrac_inherits_Ucesnik] FOREIGN KEY ([JMBG]) REFERENCES [dbo].[Ucesniks] ([JMBG]) ON DELETE CASCADE
);


GO
create trigger TrigerInsertion
on Ucesniks_Igrac
for insert
as
declare @IdIgraca int;
declare @action varchar(100);
select @IdIgraca = i.JMBG from inserted i;
set @action = 'Inserted record';
insert into audit
(IdIgraca, AuditMessage2, AuditDatetime)
values
(@IdIgraca, @action, getdate());
print 'after insert trigger fired!'
GO
create trigger DeleteIgracaTrigger on Ucesniks_Igrac
for delete as delete from IgracTim 
where Igracs_JMBG in (select deleted.JMBG from deleted)