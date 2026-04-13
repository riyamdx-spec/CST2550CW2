# BettingSystemsTests.Tests

A dedicated MSTest unit and integration test project for the BettingSystem application.

## What This Test Project Does

1. **Validates custom data structures**  
   Tests the correctness of the hand-built `MyList<T>`, `MyDictionary<K,V>`, and `MyLinkedList<T>` classes — covering adding, removing, indexing, resizing, and null-key guards to confirm they behave like standard collections.

2. **Verifies core business-model logic**  
   Tests `BetSlip` and `AppUser` models in isolation — including adding/updating/removing bets, total-odds calculation, payout computation, and user-role assignment — without any database or UI involvement.

3. **Checks all input-validation rules**  
   Tests every method of the `Validation` service (passwords, emails, ages, amounts, card numbers, CVVs, expiry dates, scores, and match entries) with both valid and invalid inputs to ensure boundary conditions and error messages are correct.

4. **Tests service-layer behaviour in memory**  
   Tests `SessionManager`, `Simulator`, `OddsGenerator`, `MatchManager`, `WalletService`, `AddNewMatchService`, and `BetSlipFilter` entirely in-memory — verifying filtering, sorting, odds generation, session state, and match scheduling without hitting a real database.

5. **Integration-tests the database access layer**  
   Tests `DatabaseManager` against a real SQL Server database — covering user registration, login, wallet transactions, match and odds persistence, bet-slip saving, game-result recording, and financial analytics to confirm that every query and stored procedure produces the expected data.

## Notes

Odds-generation methodology and references are documented in the root `README.md` under `Testing -> Odds Generation` and `References -> Odds Generation References`.
