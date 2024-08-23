using AutoMapper;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.FundingManagement;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models.FundingManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
    public class FundingManagementService : IFundingManagementService
    {
        #region Fields

        private IMapper _mapper;
        private INpoRepository _npoRepository;
        private INpoProfileRepository _npoProfileRepository;
        private IFundingCaptureRepository _fundingCaptureRepository;

        #endregion

        #region Constructors

        public FundingManagementService(
            IMapper mapper,
            INpoRepository npoRepository,
            INpoProfileRepository npoProfileRepository,
            IFundingCaptureRepository fundingCaptureRepository
            )
        {
            _mapper = mapper;
            _npoRepository = npoRepository;
            _npoProfileRepository = npoProfileRepository;
            _fundingCaptureRepository = fundingCaptureRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<NpoViewModel>> GetAll()
        {
            List<NpoViewModel> viewModel = new List<NpoViewModel>();
            var npos = await _npoRepository.GetEntitiesWithoutDetails();

            foreach (var npo in npos)
            {
                var npoViewModel = _mapper.Map<NpoViewModel>(npo);
                npoViewModel.FundingCaptureViewModels.AddRange(
                    _mapper.Map<List<FundingCaptureViewModel>>(
                        npo.FundingCaptures));

                viewModel.Add(npoViewModel);
            }

            return viewModel;
        }

        public async Task<NpoViewModel> GetById(int id)
        {
            var viewModel = await _fundingCaptureRepository.GetById(id);
            return _mapper.Map<NpoViewModel>(viewModel);
        }

        public async Task<NpoViewModel> GetByNpoId(int npoId)
        {
            var npo = await _npoRepository.GetById(npoId);
            var profile = await _npoProfileRepository.GetByNpoId(npoId);

            var viewModel = _mapper.Map<NpoViewModel>(npo);
            viewModel.NpoProfileId = profile.Id;

            return viewModel;
        }

        #endregion
    }
}
