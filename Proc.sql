create proc findSymptomViaID
@symptom_id int
as
	select symptom_id
	from SymptomsTable where symptom_id = @symptom_id