-- Fix for Municipality spelling in dropdown
UPDATE [dropdown].[ManicipalityDemographics]
SET Name = REPLACE(Name, 'Manicipality', 'Municipality')
WHERE Name LIKE '%Manicipality%';

-- Add default mapping for CHS District to City of Cape Town
INSERT INTO [mapping].[ActivitySubDistricts]
(Name, IsActive, ActivityId, SubstructureId, AreaId)
SELECT 
    'City of Cape Town Municipality',
    1,
    act.ActivityId,
    1, -- Replace with actual SubstructureId for Cape Town
    1  -- Replace with actual AreaId for Cape Town
FROM [dbo].[Activities] act
WHERE NOT EXISTS (
    SELECT 1 
    FROM [mapping].[ActivitySubDistricts] asd 
    WHERE asd.ActivityId = act.ActivityId
    AND asd.Name = 'City of Cape Town Municipality'
);