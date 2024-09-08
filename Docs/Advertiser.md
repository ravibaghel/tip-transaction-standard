# Advertiser information

## Advertiser Properties

| Property            | Type     | Required | Constraints                  | Description                                                  |
|---------------------|----------|----------|------------------------------|--------------------------------------------------------------|
| advertiserIds       | Array    | Required | {"minItems":1}               | Array of identifier objects used to identify the advertiser id and its source system |
| advertiserName      | String   | Required | {"example": "Hyundai"}       | Advertiser name                                              |
| advertiserReference | String   | Optional |                              | External advertiser reference to support data mapping differences between systems |
