export const environment = {
  production: false,
  primefacesUrl: 'https://primefaces.org/primeng/#/',
  environmentName: 'Local',
  appInsights: {
    instrumentationConnString: 'InstrumentationKey=3e255d0b-6da1-4c4a-bc33-ac766b657c57;IngestionEndpoint=https://southafricanorth-1.in.applicationinsights.azure.com/'
  },

  b2cConfig: {
    clientId: "5bc1ab42-d03a-405c-94eb-499e3297b020",  
    redirectUrl: "http://localhost:4200",
    postLogoutRedirectUri: "http://localhost:4200",
    names: {
      signUpSignIn: "B2C_1_B2B_TAPS_SignUp_SignIn",
      forgotPassword: "B2C_1_B2B_TAPS_Password_Reset",
      editProfile: "B2C_1_B2B_TAPS_Profile_Editing",
      signUp: "B2C_1_B2B_TAPS_SignUp"
    },
    authorities: {
      signUpSignIn: {
        authority: "https://wcgb2c.b2clogin.com/wcgb2c.onmicrosoft.com/B2C_1_B2B_TAPS_SignUp_SignIn",
      },
      forgotPassword: {
        authority: "https://wcgb2c.b2clogin.com/wcgb2c.onmicrosoft.com/B2C_1_B2B_TAPS_Password_Reset",
      },
      editProfile: {
        authority: "https://wcgb2c.b2clogin.com/wcgb2c.onmicrosoft.com/B2C_1_B2B_TAPS_Profile_Editing"
      },
      signUp: {
        authority: "https://wcgb2c.b2clogin.com/wcgb2c.onmicrosoft.com/B2C_1_B2B_TAPS_SignUp"
      }
    },
    authorityDomain: "wcgb2c.b2clogin.com",
    resources: {
      scopes: ['https://wcgb2c.onmicrosoft.com/5bc1ab42-d03a-405c-94eb-499e3297b020/crud.all', 'openid', 'profile'],
      uri: 'http://localhost:61250'
    }
  }
};