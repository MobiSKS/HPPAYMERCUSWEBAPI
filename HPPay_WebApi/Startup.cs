using HPPay.DataRepository;
using HPPay.DataRepository.Account;
using HPPay.DataRepository.AccountStatment;
using HPPay.DataRepository.AdvanceSearch;
using HPPay.DataRepository.AggregatorCustomer;
using HPPay.DataRepository.AGS;
using HPPay.DataRepository.AMEXCreditPouch;
using HPPay.DataRepository.AshokLeyland;
using HPPay.DataRepository.BasicSearch;
using HPPay.DataRepository.BasicSearchByCard;
using HPPay.DataRepository.Card;
using HPPay.DataRepository.City;
using HPPay.DataRepository.COMCO;
using HPPay.DataRepository.CommonRequests;
using HPPay.DataRepository.ConfigureAlert;
using HPPay.DataRepository.Country;
using HPPay.DataRepository.CountryRegion;
using HPPay.DataRepository.CountryZone;
using HPPay.DataRepository.Customer;
using HPPay.DataRepository.CustomerAPI;
using HPPay.DataRepository.CustomerFeedbackRepository;
using HPPay.DataRepository.DBDapper;
using HPPay.DataRepository.DealerCreditManage;
using HPPay.DataRepository.DICV;
using HPPay.DataRepository.District;
using HPPay.DataRepository.Driver;
using HPPay.DataRepository.DTP;
using HPPay.DataRepository.EFT;
using HPPay.DataRepository.EGVAPI;
using HPPay.DataRepository.Fastlane;
using HPPay.DataRepository.FSE;
using HPPay.DataRepository.HDFCCreditPouch;
using HPPay.DataRepository.HDFCPG;
using HPPay.DataRepository.HLFL;
using HPPay.DataRepository.Hotlist;
using HPPay.DataRepository.HQ;
using HPPay.DataRepository.IciciAPI;
using HPPay.DataRepository.ICICICreditPouch;
using HPPay.DataRepository.IdfcAPI;
using HPPay.DataRepository.JCB;
using HPPay.DataRepository.Login;
using HPPay.DataRepository.LoyaltyRedemption;
using HPPay.DataRepository.M2PAPI;
using HPPay.DataRepository.Merchant;
using HPPay.DataRepository.MerchantDashboard;
using HPPay.DataRepository.MobilePaymentGateway;
using HPPay.DataRepository.Officer;
using HPPay.DataRepository.OTC;
using HPPay.DataRepository.ParentCustomer;
using HPPay.DataRepository.PayCode;
using HPPay.DataRepository.PayEnrollmentFee;
using HPPay.DataRepository.PCICICICreditPouch;
using HPPay.DataRepository.RBE;
using HPPay.DataRepository.RechargeCCMS;
using HPPay.DataRepository.RegionalOffice;
using HPPay.DataRepository.SadakKeSathi;
using HPPay.DataRepository.Settings;
using HPPay.DataRepository.SFLAPI;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataRepository.State;
using HPPay.DataRepository.STFC;
using HPPay.DataRepository.STFCAPI;
using HPPay.DataRepository.Tatkal;
using HPPay.DataRepository.Terminal;
using HPPay.DataRepository.TMFL;
using HPPay.DataRepository.TMS;
using HPPay.DataRepository.Transaction;
using HPPay.DataRepository.UserManage;
using HPPay.DataRepository.VolvoEicher;
using HPPay.DataRepository.ZonalOffice;
using HPPay.Infrastructure.Swagger;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExceptionFilter;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using HPPay.DataRepository.CustomerRelationship;
using HPPay.DataRepository.IVR;
using HPPay.DataRepository.PayU;

namespace HPPay_WebApi
{
    public class Startup
    {
        private readonly string _policyName = "CorsPolicy";
        private readonly string _anotherPolicy = "AnotherCorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.WithOrigins("https://localhost:5155")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
                opt.AddPolicy(name: _anotherPolicy, builder =>
                {
                    builder.WithOrigins("https://localhost:5021")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

                opt.AddPolicy(name: _anotherPolicy, builder =>
                {
                    builder.WithOrigins("http://180.179.222.161/dtpwebapi")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

                opt.AddPolicy(name: _anotherPolicy, builder =>
                {
                    builder.WithOrigins("http://localhost/dtpapi")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

                opt.AddPolicy(name: _anotherPolicy, builder =>
                {
                    builder.WithOrigins("https://dtpapi.mloyalretail.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<DapperContext>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IOfficerRepository, OfficerRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IHQRepository, HQRepository>();
            services.AddScoped<IMerchantRepository, MerchantRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IRegionalOfficeRepository, RegionalOfficeRepository>();
            services.AddScoped<IZonalOfficeRepository, ZonalOfficeRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<ICountryRegionRepository, CountryRegionRepository>();
            services.AddScoped<ICountryZoneRepository, CountryZoneRepository>();
            services.AddScoped<IHotlistRepository, HotlistRepository>();
            services.AddScoped<IAshokLeylandRepository, AshokLeylandRepository>();
            services.AddScoped<ITerminalRepository, TerminalRepository>();
            services.AddScoped<IOTCRepository, OTCRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ITatkalRepository, TatkalRepository>();
            services.AddScoped<ITMSRepository, TMSRepository>();
            services.AddScoped<IRBERepository, RBERepository>();
            services.AddScoped<IDTPRepository, DTPRepository>();
            services.AddScoped<ICustomerAPIRepository, CustomerAPIRepository>();
            services.AddScoped<IAggregatorCustomerRepository, AggregatorCustomerRepository>();
            services.AddScoped<IUserManageRepository, UserManageRepository>();
            services.AddScoped<IDealerCreditManageRepository, DealerCreditManageRepository>();
            services.AddScoped<ICOMCORepository, COMCORepository>();
            services.AddScoped<CustomAuthenticationFilter>();
            services.AddScoped<APINSecretKeyCheckFilter>();
            services.AddScoped<CustomerAPIAuthenticationFilter>();
            services.AddScoped<AGSAuthenticationFilter>();

            services.AddScoped<SFLAPIAuthenticationFilter>();
            services.AddScoped<STFCAPIAuthenticationFilter>();
            services.AddScoped<M2PAPIAuthenticationFilter>();
            services.AddScoped<HLFLAPIAuthenticationFilter>();
            services.AddScoped<TMFLAPIAuthenticationFilter>();
            services.AddScoped<IConfigureAlertRepository, ConfigureAlertRepository>();
            services.AddScoped<IUserManageRepository, UserManageRepository>();
            services.AddScoped<IIdfcApiRepository, IdfcApiRepository>();
            services.AddScoped<IIciciApiRepository, IciciApiRepository>();
            services.AddScoped<ICreditPouchRepository, CreditPouchRepository>();
            services.AddScoped<ICreditPouchRepositoryICICI, CreditPouchRepositoryICICI>();
            services.AddScoped<ICreditPouchRepositoryAMEX, CreditPouchRepositoryAMEX>();
            services.AddScoped<IVolcoEicherRepository, VolcoEicherRepository>();
            services.AddScoped<IDICVRepository, DICVRepository>();
            services.AddScoped<IJCBRepository, JCBRepository>();
            services.AddScoped<IParentCustomerRepository, ParentCustomerRepository>();
            services.AddScoped<IRechargeCCMSRepository, RechargeCCMSRepository>();
            services.AddScoped<IBasicSearchByCustomerRepository, BasicSearchByCustomerRepository>();
            services.AddScoped<IBasicSearchByCardRepository, BasicSearchByCardRepository>();
            services.AddScoped<IPCCreditPouchRepository, PCCreditPouchRepository>();
            services.AddScoped<IPCCreditPouchRepositoryICICI, PCCreditPouchRepositoryICICI>();
            services.AddScoped<IAccountStatmentRepository, AccountStatmentRepository>(); 
            services.AddScoped<IEFTRepository, EFTRepository>();
            services.AddScoped<ISFLAPIRepository, SFLAPIRepository>();
            services.AddScoped<ISTFCAPIRepository, STFCAPIRepository>();
            services.AddScoped<IM2PAPIRepository, M2PAPIRepository>();
            services.AddScoped<IHLFLRepository, HLFLRepository>();
            services.AddScoped<ITMFLRepository, TMFLRepository>();
            services.AddScoped<ICustomerDashboardRepository, CustomerDashboardRepository>();
            services.AddScoped<IMerchantDashboardRepository, MerchantDashboardRepository>();
            services.AddScoped<IMODashboardRepository, MODashboardRepository>();
            services.AddScoped<ICommonValidations, CommonValidations>();
            services.AddScoped<IRequestService, RequestServices>();
            services.AddScoped<IPayCodeRepository, PayCodeRepository>();
            services.AddScoped<IEGVAPIRepository, EGVAPIRepository>();

            services.AddScoped<IAdvanceSearchRepositary, AdvanceSearchRepositary>();
            services.AddScoped<IStfcApiRepository, StfcApiRepository>();
            services.AddScoped<ISMSGetSendRepository, SMSGetSendRepository>();
            services.AddScoped<IAGSRepository, AGSRepository>();
            services.AddScoped<ICustomerFeedbackRepository, CustomerFeedbackRepositary>();
            services.AddScoped<IHDFCPGRepository, HDFCPGRepository>();
            services.AddScoped<ILoyaltyRedemptionRepository, LoyaltyRedemptionRepository>();
            services.AddScoped<IPayEnrollmentFeeByHDFCRepository, PayEnrollmentFeeByHDFCRepository> ();
            services.AddScoped<IMobilePaymentGatewayRepository, MobilePaymentGatewayRepository>(); 
                services.AddScoped<IFSERepository, FSERepository>();
            services.AddScoped<ICustomerRelationshipRepository, CustomerRelationshipRepository>();
            services.AddScoped<ISadakKeSathiRepository, SadakKeSathiRepository>();
            services.AddScoped<IFastlaneIntegrationRepository, FastlaneIntegrationRepository>();
            //Parvez Shaik| IVR Changes| START
            services.AddScoped<IIVRCustomerRepository, IVRCustomerRepository>();
            services.AddScoped<IIVRDriverRepository, IVRDriverRepository>();
            services.AddScoped<IPayURepository, PayURepository>();
            
            //Parvez Shaik| IVR Changes| END
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
            
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(ValidateModelAttribute));
            //});
            services.AddMvc(
                config =>
                {
                    config.Filters.Add(typeof(CustomExceptionFilter));
                    config.Filters.Add(typeof(ValidateModelAttribute));
                }
            );//.AddFluentValidation();
            // services.AddControllers();
            services.AddControllers(config =>
            {
                config.Filters.Add(typeof(LoggingFilterAttribute));
            })

             .AddNewtonsoftJson(options =>
             {
                 // options.SerializerSettings.TraceWriter = new NLogTraceWriter();
                 //   options.SerializerSettings.ContractResolver = new DefaultContractResolver();

             });

            services.AddControllers().AddNewtonsoftJson();
            
            //services.AddSwaggerGen();
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "MQWebAPI",
                    Version = "v2",
                    //Description = "Sample service for Learner",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            
            services.Configure<KestrelServerOptions>(options =>
             {
                 options.AllowSynchronousIO = true;
                 //options.Limits.MaxRequestBodySize = null; //did not worked
                 options.Limits.MaxRequestBodySize = int.MaxValue;
                 options.Limits.MaxRequestBufferSize = int.MaxValue;
                 options.Limits.MaxConcurrentConnections = int.MaxValue;
                 options.Limits.MaxRequestHeaderCount = int.MaxValue;
                 options.Limits.MaxResponseBufferSize = int.MaxValue;
                 options.Limits.MaxConcurrentUpgradedConnections = int.MaxValue;
                 options.Limits.MaxRequestHeadersTotalSize = int.MaxValue;
                 options.Limits.MaxRequestLineSize = int.MaxValue;
                 options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
                 options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(30);
             });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
                //options.MaxRequestBodySize = null;
                options.MaxRequestBodySize = int.MaxValue;
                options.MaxRequestBodyBufferSize = int.MaxValue;
                options.AutomaticAuthentication = true;
                
            });

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.MaxRequestBodySize = int.MaxValue;
            //});

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.BufferBodyLengthLimit = int.MaxValue;
                x.MultipartBoundaryLengthLimit = int.MaxValue;
                x.MemoryBufferThreshold = int.MaxValue;
                x.KeyLengthLimit = int.MaxValue;
                x.MultipartHeadersCountLimit = int.MaxValue;
                x.ValueCountLimit = int.MaxValue;
                x.MultipartHeadersLengthLimit = int.MaxValue;
                x.BufferBody = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "CustomerKYCImage")),
                RequestPath = "/CustomerKYCImage"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
           Path.Combine(Directory.GetCurrentDirectory(), "OfficerKYCImage")),
                RequestPath = "/OfficerKYCImage"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), "COMCOImage")),
                RequestPath = "/COMCOImage"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), "EFTRechargeFile")),
                RequestPath = "/EFTRechargeFile"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), "InfinityRechargeFile")),
                RequestPath = "/InfinityRechargeFile"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), "ISurePayRechargeFile")),
                RequestPath = "/ISurePayRechargeFile"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), "HLFLRcDoc")),
                RequestPath = "/HLFLRcDoc"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
         Path.Combine(Directory.GetCurrentDirectory(), "HLFLRcDoc")),
                RequestPath = "/TMFLRcDoc"
            });
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), "CustomerKYCFastTagImage")),
                RequestPath = "/CustomerKYCFastTagImage"
            });


            app.UseRouting();
            app.UseSession();
            app.UseCors(_policyName);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("../swagger/v2/swagger.json", "PlaceInfo Services"));            

        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseKestrel(o => { o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30); })
        .Build();

    }
}
