-- Add Quarter selection functionality to Actuals tab

-- 1. Ensure FrequencyPeriods table has proper quarters
INSERT INTO [dropdown].[FrequencyPeriods] 
(Name, SystemName, IsActive, CreatedUserId, CreatedDateTime, FrequencyId)
VALUES
('Quarter 1', 'Q1', 1, 1, GETDATE(), 4),
('Quarter 2', 'Q2', 1, 1, GETDATE(), 4),
('Quarter 3', 'Q3', 1, 1, GETDATE(), 4),
('Quarter 4', 'Q4', 1, 1, GETDATE(), 4);

-- 2. Update WorkplanActuals table to include quarter info
ALTER TABLE [indicator].[WorkplanActuals]
ADD QuarterId int NULL;

-- 3. Add foreign key constraint
ALTER TABLE [indicator].[WorkplanActuals]
ADD CONSTRAINT FK_WorkplanActuals_FrequencyPeriods
FOREIGN KEY (QuarterId) REFERENCES [dropdown].[FrequencyPeriods](Id);