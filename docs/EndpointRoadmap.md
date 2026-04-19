# Endpoint Roadmap

## Current implementation

Implemented in this library today:

- `POST /seller/logtimes`
- `POST /buyer/logtimes/subscription`
- `POST /buyer/commercialInstructions`
- `POST /seller/commercialInstructions`
- `POST /buyer/rfps`
- `POST /seller/proposals`
- `POST /buyer/proposals`
- `POST /buyer/orders`
- `POST /seller/orders`
- `POST /buyer/inventoryAvails/subscription`
- `POST /seller/inventoryAvails`
- `POST /seller/invoices`
- `POST /seller/makegood/guidelines`
- `POST /buyer/makegood/guidelines`
- `POST /seller/makegood/offers`
- `POST /buyer/makegood/offers`
- `POST /buyer/creativeAssets`
- `POST /buyer/impressions/subscription`
- `POST /seller/impressions/notification`

## Remaining endpoint families from `tip-initiative-apis` `develop`

- `buyerAudiences`
- `sellerAudiences`
- `sellerPoliticalCompetitives`

## Recommended implementation order

1. `buyerAudiences` and `sellerAudiences`
2. `sellerPoliticalCompetitives`

## Notes from the TIP implementation guides

- Content negotiation is a first-class part of TIP. JSON and XML should both be supported through `Content-Type` and `Accept`.
- XML examples in TIP 6.0.0 use the namespace `https://tip.schemas.org/v6.0.0`.
- Implementations may need to support multiple TIP or legacy payload formats on the same endpoint over time.
- Date and time handling is mixed: some fields are UTC transport timestamps, while sales and air-time fields are often local-to-media-outlet concepts.
- Validation should reject malformed payloads with proper TIP-style error responses rather than relying on transport-level failures.
- Security guidance strongly favors HTTPS, OAuth 2.0 or better, short-lived access tokens, input validation, proper HTTP status codes, logging, and exclusion of sensitive secrets from logs.

## Notes from the TIP workbook

The workbook tabs align closely with the main endpoint families:

- buyerinventoryAvailsSubscription
- sellerinventoryAvails
- buyerRFPS
- sellerproposals
- buyerproposals
- buyerorders
- sellerorders
- buyercommercialInstructions
- sellercommercialInstructions
- sellermakegoodGuidelines
- buyermakegoodGuidelines
- sellermakegoodOffers
- buyermakegoodOffers
- buyerlogTimessubscription
- sellerlogTimes
- buyerimpressionssubscription
- sellerimpressionsnotification
- buyeraudiencessubscription
- selleraudiences
- sellerinvoices
