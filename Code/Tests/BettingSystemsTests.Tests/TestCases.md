# Test Case Documentation

## Table of Contents

- [Data Structures](#data-structures)
  - [MyList](#mylist)
  - [MyDictionary](#mydictionary)
  - [MyLinkedList](#mylinkedlist)
- [AI Agent (Financial Report)](#ai-agent-financial-report)

---

## Data Structures

### MyList

| Test ID | Test Name | Description | Input | Expected Output | Pass/Fail |
|---------|-----------|-------------|-------|-----------------|-----------|
| DS-ML-01 | `Constructor_EmptyList_StartsWithZeroCount` | A newly created list should have zero items and report as empty | No input — empty constructor | `Count = 0`, `IsEmpty() = true` | Pass |
| DS-ML-02 | `Add_ItemsIncreaseCount_AndKeepOrder` | Adding items should increment count and preserve insertion order | Add 10, 20, 30 | `Count = 3`, `list[0]=10`, `list[1]=20`, `list[2]=30` | Pass |
| DS-ML-03 | `Indexer_GetOutOfRange_Throws` | Accessing a negative or out-of-bounds index should throw | `list[-1]`, `list[1]` on a single-item list | `IndexOutOfRangeException` thrown for both | Pass |
| DS-ML-04 | `Remove_RemovesFirstMatchingValue` | Removing a value should delete only the first matching occurrence | List: 5, 8, 5 — Remove(5) | `Count = 2`, remaining: 8, 5 | Pass |
| DS-ML-05 | `RemoveAll_RemovesOnlyMatchingValues` | RemoveAll with predicate should delete all values satisfying the condition | List: 1, 2, 3, 4 — RemoveAll(even) | `Count = 2`, remaining: 1, 3 | Pass |
| DS-ML-06 | `Reverse_ReversesElementsInPlace` | Reverse should reorder all elements from tail to head in-place | List: A, B, C | `Count = 3`, order becomes C, B, A | Pass |
| DS-ML-07 | `AddRange_AppendsAllElementsFromOtherList` | AddRange should append all items from another list in source order | Base: [1]; Range: [2, 3] | `Count = 3`, order: 1, 2, 3 | Pass |
| DS-ML-08 | `InsertMatch_InsertsByGameDateDescending` | InsertMatch should insert football matches sorted newest-first by game date | Dates: Jan 1, Feb 1, Jan 15 | Order by GameID: newest (2), middle (3), oldest (1) | Pass |

---

### MyDictionary

| Test ID | Test Name | Description | Input | Expected Output | Pass/Fail |
|---------|-----------|-------------|-------|-----------------|-----------|
| DS-MD-01 | `Add_NewKey_AddsEntryAndIncreasesCount` | Adding a new key should store the value and increment count | Add `"one" → 1` | `Count = 1`, `dict["one"] = 1` | Pass |
| DS-MD-02 | `Add_ExistingKey_UpdatesValueWithoutChangingCount` | Adding an already-present key should overwrite the value, not add a duplicate | Add `"k"→1`, then `"k"→99` | `Count = 1`, `dict["k"] = 99` | Pass |
| DS-MD-03 | `Remove_ExistingKey_ReturnsTrueAndRemovesValue` | Removing a key that exists should return true and make the key inaccessible | Add `"x"→"value"`, then Remove(`"x"`) | Returns `true`, `Count = 0`, `ContainsKey("x") = false` | Pass |
| DS-MD-04 | `Remove_MissingKey_ReturnsFalse` | Removing a key not in the dictionary should return false without throwing | Remove(`"missing"`) on empty dict | Returns `false`, no exception | Pass |
| DS-MD-05 | `TryGetValue_ExistingAndMissingKeys_ReturnExpectedResult` | TryGetValue should return correct bool and out-value for both hit and miss | Add `10→"ten"`, TryGet 10, then TryGet 999 | Hit: `true`, `"ten"`; Miss: `false`, `null` | Pass |
| DS-MD-06 | `ContainsKey_ReturnsTrueOnlyForExistingKeys` | ContainsKey should only return true for keys that have been added | Add key 1, check key 1 and key 2 | `ContainsKey(1) = true`, `ContainsKey(2) = false` | Pass |
| DS-MD-07 | `Resize_AfterManyInsertions_AllValuesRemainAccessible` | All values should remain accessible after enough inserts to trigger internal resize | Insert 60 key-value pairs (`i → "vi"`) | `Count = 60`, all `dict[i] = "vi"` still accessible | Pass |
| DS-MD-08 | `NullKey_OnReferenceTypeKey_ThrowsArgumentNullException` | Null keys should be rejected with `ArgumentNullException` across Add, ContainsKey, and Remove | Call Add, ContainsKey, Remove each with `null` key | `ArgumentNullException` thrown in all three cases | Pass |

---

### MyLinkedList

| Test ID | Test Name | Description | Input | Expected Output | Pass/Fail |
|---------|-----------|-------------|-------|-----------------|-----------|
| DS-LL-01 | `Constructor_StartsEmpty` | A newly created linked list should have zero nodes and a null head | No input — empty constructor | `Count = 0`, `First = null` | Pass |
| DS-LL-02 | `AddFirst_AddsAtHead_AndUpdatesCount` | AddFirst should insert at the head and correctly wire Previous/Next pointers | AddFirst(10), then AddFirst(20) | `Count = 2`, `First.Value = 20`, `n2.Next.Value = 10`, `n1.Previous = n2` | Pass |
| DS-LL-03 | `Remove_HeadNode_UpdatesHead` | Removing the current head should promote the next node to head | AddFirst(1), AddFirst(2); Remove(2) | `Count = 1`, `First.Value = 1`, `First.Previous = null` | Pass |
| DS-LL-04 | `Remove_MiddleNode_ReconnectsNeighbors` | Removing a middle node should relink its neighbors to each other | AddFirst(1), AddFirst(2), AddFirst(3); Remove(2) | `Count = 2`, `head.Next = tail`, `tail.Previous = head` | Pass |
| DS-LL-05 | `Remove_NullNode_ReturnsFalse` | Passing null to Remove should return false without throwing | Remove(`null`) | Returns `false`, no exception | Pass |
| DS-LL-06 | `Clear_RemovesAllNodes` | Clear should reset the list to an empty state with null head | AddFirst("A"), AddFirst("B"), then Clear() | `Count = 0`, `First = null` | Pass |

---

## AI Agent (Financial Report)

The AI Agent feature is implemented in `AdminFinancialPage.cs` and uses the **Google Gemini API** (`gemini-3-flash-preview`) to generate an executive financial report from live platform data. The test cases below are manual UI tests.

| Test ID | Test Name | Description | Preconditions | Steps | Expected Output | Pass/Fail |
|---------|-----------|-------------|---------------|-------|-----------------|-----------|
| AI-01 | Valid API Key — Report Generated Successfully | Confirms the agent generates and displays a formatted financial report when a valid API key and financial data are present | Valid `GOOGLE_API_KEY` in `App.Config`; at least one month of transaction data in DB | Log in as admin → Navigate to Finance page → Click **Generate Report** | Report panel expands; report text appears split into four sections (PERFORMANCE OVERVIEW, REVENUE & PROFITABILITY, USER ACTIVITY & ENGAGEMENT, OUTLOOK & RECOMMENDATIONS); status label shows generation timestamp | |
| AI-02 | Missing API Key — Error Displayed | Confirms a clear error is shown instead of crashing when no API key is configured | `GOOGLE_API_KEY` is blank or missing in `App.Config` | Log in as admin → Navigate to Finance page → Click **Generate Report** | Panel collapses; error message `"Failed to generate report. Please try again."` appears; status label shows the error; button reverts to "Generate Report" | |
| AI-03 | Hide Report — Panel Collapses | Confirms clicking the button a second time after a report is shown collapses the panel | A report has already been generated (AI-01 passed) | After report is visible, click **Hide Report** | AI panel collapses to its default height; button text reverts to "Generate Report"; status label is hidden | |
| AI-04 | Financial Data Reflected in Report | Confirms the generated report references actual platform figures (revenue, users, bets) sourced from the DB | Valid API key; DB populated with known financial summary values | Log in as admin → Navigate to Finance page → Click **Generate Report** → Read report content | Report narrative references figures consistent with the financial summary panel (total revenue, active users, bet totals) | |
| AI-05 | Report Format — Plain Text Only | Confirms the agent response contains no markdown formatting characters such as `*`, `**`, `#`, or bullet symbols | Valid API key; financial data present | Click **Generate Report** and inspect the report text in the panel | Report text uses plain sentences and CAPITALISED section headers only — no asterisks, hash symbols, or bullet points | |
| AI-06 | Button Disabled During Generation | Confirms the Generate Report button is disabled while the API call is in progress to prevent duplicate requests | Valid API key; financial data present; moderate network latency | Click **Generate Report** and immediately inspect button state before the response arrives | Button is disabled and labelled `"Generating..."` until the response is received, then re-enabled | |

