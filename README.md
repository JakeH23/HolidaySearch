# On the Beach - Holiday Search programming exercise

## Description

This exercise is designed to measure your understanding of some common programming principles. We've designed it to be language agnostic so please complete it in the programming language you feel most comfortable using.

## Hints and Tips

 * We aim to take up no more than four hours of your personal time.
 * We believe that Test Driven Development will produce higher quality code.
 * It would be great if you can show your process in the form of granular commit messages.
 * We're not looking for a UI or command line output, just the code and some tests to show it works.

## Holiday Search

Taking the two JSON files of flights and hotels as source data, please create a small library of code that provides a basic holiday search feature. 

The first search result should be the best value holiday we can provide, based on the customers requirements.

Use the test cases listed below to verify the success of your work, add more tests as you see fit.

Here is an example of how the finished library could work, you're welcome to put your own spin on it.


    var holidaySearch = new HolidaySearch({
      DepartingFrom: 'MAN',
      TravelingTo: 'AGP',
      DepartureDate: '2023/07/01'
      Duration: 7
      });

    holidaySearch.Results.First() # Returns the Best of the matching results
    holidaySearch.Results.First().TotalPrice # '£900.00'
    holidaySearch.Results.First().Flight.Id # 4
    holidaySearch.Results.First().Flight.DepartingFrom # 'MAN'
    holidaySearch.Results.First().Flight.TravalingTo # 'AGP'
    holidaySearch.Results.First().Flight.Price
    holidaySearch.Results.First().Hotel.Id # 3    
    holidaySearch.Results.First().Hotel.Name
    holidaySearch.Results.First().Hotel.Price


## Test cases

Here are some example test cases

#### Customer #1

##### Input
 * Departing from: Manchester Airport (MAN)
 * Traveling to: Malaga Airport (AGP)
 * Departure Date: 2023/07/01
 * Duration: 7 nights

##### Expected result  
 * Flight 2 and Hotel 9

### Customer #2

##### Input
 * Departing from: Any London Airport
 * Traveling to: Mallorca Airport (PMI)
 * Departure Date: 2023/06/15
 * Duration: 10 nights

##### Expected result  
 * Flight 6 and Hotel 5

### Customer #3

##### Input
 * Departing from: Any Airport
 * Traveling to: Gran Canaria Airport (LPA)
 * Departure Date: 2022/11/10
 * Duration: 14 nights

##### Expected result  
 * Flight 7 and Hotel 6

## Flight data

```json
[
  {
    "id": 1,
    "airline": "First Class Air",
    "from": "MAN",
    "to": "TFS",
    "price": 470,
    "departure_date": "2023-07-01"
  },
  {
    "id": 2,
    "airline": "Oceanic Airlines",
    "from": "MAN",
    "to": "AGP",
    "price": 245,
    "departure_date": "2023-07-01"
  },
  {
    "id": 3,
    "airline": "Trans American Airlines",
    "from": "MAN",
    "to": "PMI",
    "price": 170,
    "departure_date": "2023-06-15"
  },
  {
    "id": 4,
    "airline": "Trans American Airlines",
    "from": "LTN",
    "to": "PMI",
    "price": 153,
    "departure_date": "2023-06-15"

  },
  {
    "id": 5,
    "airline": "Fresh Airways",
    "from": "MAN",
    "to": "PMI",
    "price": 130,
    "departure_date": "2023-06-15"
  },
  {
    "id": 6,
    "airline": "Fresh Airways",
    "from": "LGW",
    "to": "PMI",
    "price": 75,
    "departure_date": "2023-06-15"
  },
  {
    "id": 7,
    "airline": "Trans American Airlines",
    "from": "MAN",
    "to": "LPA",
    "price": 125,
    "departure_date": "2022-11-10"
  },
  {
    "id": 8,
    "airline": "Fresh Airways",
    "from": "MAN",
    "to": "LPA",
    "price": 175,
    "departure_date": "2023-11-10"
  },
  {
    "id": 9,
    "airline": "Fresh Airways",
    "from": "MAN",
    "to": "AGP",
    "price": 140,
    "departure_date": "2023-04-11"
  },
  {
    "id": 10,
    "airline": "First Class Air",
    "from": "LGW",
    "to": "AGP",
    "price": 225,
    "departure_date": "2023-07-01"
  },
  {
    "id": 11,
    "airline": "First Class Air",
    "from": "LGW",
    "to": "AGP",
    "price": 155,
    "departure_date": "2023-07-01"
  },
  {
    "id": 12,
    "airline": "Trans American Airlines",
    "from": "MAN",
    "to": "AGP",
    "price": 202,
    "departure_date": "2023-10-25"
  }
]
```

## Hotel data
```json
[
  {
    "id": 1,
    "name": "Iberostar Grand Portals Nous",
    "arrival_date": "2022-11-05",
    "price_per_night": 100,
    "local_airports": ["TFS"],
    "nights": 7
  },
  {
    "id": 2,
    "name": "Laguna Park 2",
    "arrival_date": "2022-11-05",
    "price_per_night": 50,
    "local_airports": ["TFS"],
    "nights": 7
  },
  {
    "id": 3,
    "name": "Sol Katmandu Park & Resort",
    "arrival_date": "2023-06-15",
    "price_per_night": 59,
    "local_airports": ["PMI"],
    "nights": 14
  },
  {
    "id": 4,
    "name": "Sol Katmandu Park & Resort",
    "arrival_date": "2023-06-15",
    "price_per_night": 59,
    "local_airports": ["PMI"],
    "nights": 14
  },
  {
    "id": 5,
    "name": "Sol Katmandu Park & Resort",
    "arrival_date": "2023-06-15",
    "price_per_night": 60,
    "local_airports": ["PMI"],
    "nights": 10
  },
  {
    "id": 6,
    "name": "Club Maspalomas Suites and Spa",
    "arrival_date": "2022-11-10",
    "price_per_night": 75,
    "local_airports": ["LPA"],
    "nights": 14
  },
  {
    "id": 7,
    "name": "Club Maspalomas Suites and Spa",
    "arrival_date": "2022-09-10",
    "price_per_night": 76,
    "local_airports": ["LPA"],
    "nights": 14
  },
  {
    "id": 8,
    "name": "Boutique Hotel Cordial La Peregrina",
    "arrival_date": "2022-10-10",
    "price_per_night": 45,
    "local_airports": ["LPA"],
    "nights": 7
  },
  {
    "id": 9,
    "name": "Nh Malaga",
    "arrival_date": "2023-07-01",
    "price_per_night": 83,
    "local_airports": ["AGP"],
    "nights": 7
  }
  {
    "id": 10,
    "name": "Barcelo Malaga",
    "arrival_date": "2023-07-05",
    "price_per_night": 45,
    "local_airports": ["AGP"],
    "nights": 10
  }
  {
    "id": 11,
    "name": "Parador De Malaga Gibralfaro",
    "arrival_date": "2023-10-16",
    "price_per_night": 100,
    "local_airports": ["AGP"],
    "nights": 7
  }
  {
    "id": 12,
    "name": "MS Maestranza Hotel",
    "arrival_date": "2023-07-01",
    "price_per_night": 45,
    "local_airports": ["AGP"],
    "nights": 14
  },
  {
    "id": 13,
    "name": "Jumeirah Port Soller",
    "arrival_date": "2023-06-15",
    "price_per_night": 295,
    "local_airports": ["PMI"],
    "nights": 10
  },
]
```
