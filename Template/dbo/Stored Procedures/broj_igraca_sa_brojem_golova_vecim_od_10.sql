-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[broj_igraca_sa_brojem_golova_vecim_od_10]
 @retVal int OUTPUT 
AS
BEGIN
	declare @Ime_i varchar(max)
	declare @Prezime_i varchar(max)
	declare @JMBG_i bigint
	declare @BrojGolova_i int

	declare igrac_cursor cursor

	for select u.Ime, u.Prezime, u.JMBG, i.BrojGolova from Ucesniks u left outer join Ucesniks_Igrac i on u.JMBG = i.JMBG
	set @retVal = 0;
	open igrac_cursor;

	fetch next from igrac_cursor into @Ime_i, @Prezime_i, @JMBG_i, @BrojGolova_i
		while @@FETCH_STATUS = 0
		begin if(@BrojGolova_i > = 10)
			begin 
				set @retVal = @retVal + 1
			end
		fetch next from igrac_cursor
		into @Ime_i, @Prezime_i, @JMBG_i, @BrojGolova_i
	end

	close igrac_cursor
	deallocate igrac_cursor
end;
