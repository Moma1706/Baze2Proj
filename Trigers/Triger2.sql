create trigger DeleteIgracaTrigger on Ucesniks_Igrac
	for delete as delete from IgracTim 
where Igracs_JMBG in (select deleted.JMBG from deleted)