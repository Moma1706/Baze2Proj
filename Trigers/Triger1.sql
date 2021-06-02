create trigger TrigerInsertion
	on Ucesniks_Igrac
	for insert
		as
			declare @IdIgraca int;
			declare @action varchar(100);
			select @IdIgraca = i.JMBG from inserted i;
			set @action = 'Inserted record';
		insert into audit (IdIgraca, AuditMessage2, AuditDatetime) values (@IdIgraca, @action, getdate());
	print 'after insert trigger fired!'


