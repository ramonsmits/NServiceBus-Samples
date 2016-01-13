
# Use message mutator to set NServiceBus message id header

This is a modified pubsub sample that demonstrates:

- Setting of message ID by using a message mutator
- Deduplication behavior when outbox is enabled
- Enables Debug logging
- Subscribers returns a Response to the publisher
- Has an increased MaximumConcurrencyLevel to allow parallel message processing
- Shows failing outbox persistence when processing duplicate transport message in parallel
- Shows outbox not delivering messages even when handler is invoked more than once for the same message
- Publisher purposely has outbox disabled to show duplicate handling of response if dedupe would not be working at the subscriber
- Shows how a subscriber can generate a deterministic ID based on its endpoint info and incoming message ID.


It uses:

- Win32 sequential uuid generator to generate sequential uuid on this machine where it is run (used this before using the clock timestamp string to uuid)
- GuidUtility to convert a string to a guid.

The publisher generates a new ID every clock second as it uses `DateTime.ToString("s")` and a string to guid conversion.