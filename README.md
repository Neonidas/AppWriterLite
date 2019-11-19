# AppWriterLite
AppWriterLite implementation for a wizkids test.

Frontend is incomplete. Some javascript is missing to implement fetching data from the web API and displaying the results on every key press.
Backend is done.

Predictions are split into danish and english since the provided dictionary(Dictionary.db) only contains danish words.

example get request from the web API for english predictions:
https://localhost:5001/api/prediction/en/I%20like%20ca
NOTE: The english predictions are returned in a single array, not two.

example GET request for the web API for danish predictions:
https://localhost:5001/api/prediction/dk/Hej%20med%20di
NOTE: The danish predictions are returned in an array containing the two prediction results from the dictionary database and the web service.
