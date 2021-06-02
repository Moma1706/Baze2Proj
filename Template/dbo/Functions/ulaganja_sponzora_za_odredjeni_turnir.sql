-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION ulaganja_sponzora_za_odredjeni_turnir
(
	@ID_turnira as int
)
RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @retVal as int

	-- Add the T-SQL statements to compute the return value here
	select  @retVal =  sum(spon.Ulaganje) from Sponzors spon left outer join SponzorTurnir sponTur on sponTur.Sponzors_IdSponzora = spon.IdSponzora left outer join 
	Turnirs tur on tur.IdTurnira = sponTur.Turnirs_IdTurnira where tur.IdTurnira = @ID_turnira

	-- Return the result of the function
	RETURN @retVal

END
