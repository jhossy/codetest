# Codetest
This project is my take on implementing a Roman numerals-to-digits and digits-to-numerals converter. It supports any digit from 1-4000 including both '1' and '4000'.

# Web API
Two endpoints exists:

   - /api/numerals/MCMIII 
      - returns 200 OK and the corresponding digit from any given valid Roman numeral.
      - returns 400 bad request and "Invalid input" from any invalid input (Invalid characters and various validation rules - see code)
   - /api/digits/1903
      - returns 200 OK and the corresponding numeral from any given valid digit (1 - 4000).
      - returns 400 bad request and "Invalid input" from any invalid input (-1, 0)
