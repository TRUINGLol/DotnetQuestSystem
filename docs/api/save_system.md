## Save system

You can use your own quest data saving strategies different from the existing ones.

To do this, you need to implement the `ISaveSystemStrategy` interface and specify this type in the `SetSaveType()` method of the `QuestDatabase` class

Please refer to the source code for an example implementation