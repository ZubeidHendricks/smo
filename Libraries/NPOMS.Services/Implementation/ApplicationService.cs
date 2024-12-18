// ...existing imports...

public async Task createCfpActivities(DtoActivity model, string userIdentifier)
{
    var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

    var activityList = new ActivityList()
    {
        Name = model.ActivityName,
        Description = model.ActivityDescription,
        IsActive = true,
        CreatedUserId = loggedInUser.Id,
        CreatedDateTime = DateTime.Now,
    };

    await _activityListRepository.CreateAsync(activityList);

    var activity = new Activity()
    {
        ApplicationId = model.ApplicationId,
        ObjectiveId = model.ObjectiveId,
        ActivityListId = activityList.Id,
        ActivityTypeId = model.ActivityTypeId,
        Target = model.Target,
        SuccessIndicator = model.SuccessIndicator,
        FinancialYear = model.FinancialYear,
        Quarter = model.Quarter,
        IsActive = true,
        CreatedUserId = loggedInUser.Id,
        CreatedDateTime = DateTime.Now,
    };

    await _activityRepository.CreateAsync(activity);

    var activityDistrict = new ActivityDistrict()
    {
        DemographicDistrictId = model.DemographicDistrictId,
        Name = model.DemographicDistrictName,
        ActivityId = activity.Id,
        IsActive = true
    };

    await _activityDistrictRepository.CreateAsync(activityDistrict);

    var activityMunicipality = new ActivityManicipality()
    {
        // If CHS district, force DistrictDemographicId to 3
        DemographicDistrictId = model.DemographicDistrictName == "CHS" ? 3 : model.DemographicDistrictId,
        Name = "City of Cape Town Metropolitan Municipality",  // Force municipality name for CHS
        ActivityId = activity.Id,
        IsActive = true
    };

    await _activityManicipalityRepository.CreateAsync(activityMunicipality);

    var activitySubStructure = new ActivitySubStructure()
    {
        MunicipalityId = model.MunicipalityId,
        Name = model.SubstructureName,
        ActivityId = activity.Id,
        IsActive = true
    };

    await _activitySubStructureRepository.CreateAsync(activitySubStructure);

    var area = new ActivityArea()
    {
        DemographicDistrictId = model.DemographicDistrictId,
        Name = model.AreaName,
        IsActive = true,
        ActivityId = activity.Id
    };

    await _areaRepository.CreateAsync(area);

    var activitySubDistrict = new ActivitySubDistrict()
    {
        Name = model.ActivitySubDistrictsName,
        IsActive = true,
        ActivityId = activity.Id,
        SubstructureId = activitySubStructure.Id,
        AreaId = area.Id
    };

    await _activitySubDistrictRepository.CreateAsync(activitySubDistrict);
}

public async Task editCfpActivities(DtoActivity model, string userIdentifier)
{
    var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

    var activityData = await _activityRepository.GetById(model.Id);

    var activityListData = await _activityListRepository.GetById(activityData.ActivityListId);

    var activityList = new ActivityList()
    {
        Id = activityData.ActivityListId,
        Name = model.ActivityName,
        Description = model.ActivityDescription,
        IsActive = true,
        CreatedUserId = activityListData.CreatedUserId,
        CreatedDateTime = activityListData.CreatedDateTime,
        UpdatedUserId = loggedInUser.Id,
        UpdatedDateTime = DateTime.Now
    };

    await _activityListRepository.UpdateAsync1(activityList);

    var activity = new Activity()
    {
        Id = model.Id,
        ApplicationId = model.ApplicationId,
        ObjectiveId = model.ObjectiveId,
        ActivityListId = activityList.Id,
        ActivityTypeId = model.ActivityTypeId,
        Target = model.Target,
        SuccessIndicator = model.SuccessIndicator,
        FinancialYear = model.FinancialYear,
        Quarter = model.Quarter,
        IsActive = true,
        CreatedUserId = activityData.CreatedUserId,
        CreatedDateTime = activityData.CreatedDateTime,
        UpdatedUserId = loggedInUser.Id,
        UpdatedDateTime = DateTime.Now
    };

    await _activityRepository.UpdateAsync1(activity);

    var activityDistrict = new ActivityDistrict()
    {
        DemographicDistrictId = model.DemographicDistrictId,
        Name = model.DemographicDistrictName,
        ActivityId = activity.Id,
        IsActive = true
    };

    await _activityDistrictRepository.UpdateAsync1(activityDistrict);

    var activityMunicipality = new ActivityManicipality()
    {
        // If CHS district, force DistrictDemographicId to 3
        DemographicDistrictId = model.DemographicDistrictName == "CHS" ? 3 : model.DemographicDistrictId,
        Name = "City of Cape Town Metropolitan Municipality",  // Force municipality name for CHS
        ActivityId = activity.Id,
        IsActive = true
    };

    await _activityManicipalityRepository.UpdateAsync1(activityMunicipality);

    var activitySubStructure = new ActivitySubStructure()
    {
        MunicipalityId = model.MunicipalityId,
        Name = model.SubstructureName,
        ActivityId = activity.Id,
        IsActive = true
    };

    await _activitySubStructureRepository.UpdateAsync1(activitySubStructure);

    var area = new ActivityArea()
    {
        DemographicDistrictId = model.DemographicDistrictId,
        Name = model.AreaName,
        IsActive = true,
        ActivityId = activity.Id
    };

    await _areaRepository.UpdateAsync1(area);

    var activitySubDistrict = new ActivitySubDistrict()
    {
        Name = model.ActivitySubDistrictsName,
        IsActive = true,
        ActivityId = activity.Id,
        SubstructureId = activitySubStructure.Id,
        AreaId = area.Id
    };

    await _activitySubDistrictRepository.UpdateAsync1(activitySubDistrict);
}

// ...rest of the file remains unchanged...