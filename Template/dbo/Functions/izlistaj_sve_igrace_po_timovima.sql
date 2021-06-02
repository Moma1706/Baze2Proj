-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION izlistaj_sve_igrace_po_timovima 
(	
	@ID_tima as int
)
RETURNS TABLE 
AS
RETURN 
(
	select uc.Ime,uc.Prezime from Ucesniks uc left outer join Ucesniks_Igrac vlS on uc.JMBG = vlS.JMBG left outer join IgracTim ps 
		on ps.Igracs_JMBG = vlS.JMBG left outer join Tims rs on rs.IdTima = ps.Tims_IdTima
		where rs.IdTima = @ID_tima
)
