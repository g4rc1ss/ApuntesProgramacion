using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebAPI.Backend.Business.Actions.Account.Interfaces;
using WebAPI.Backend.Business.Actions.Cipher.Interfaces;
using WebAPI.Backend.Business.BusinessManager.CipherManager.Interfaces;
using WebAPI.Backend.Business.BusinessManager.IdentityManager;
using WebAPI.Backend.Business.BusinessManager.IdentityManager.Interfaces;

namespace WebAPI.Backend.Business.Actions.Cipher {
    internal class CipherAction : ICipherAction {
        private readonly ILogger<CipherAction> logger;
        private readonly ICipherManager cipherManager;

        public CipherAction(ILogger<CipherAction> logger, ICipherManager cipherManager) {
            this.logger = logger;
            this.cipherManager = cipherManager;
        }

        public Task<string> CifrarTexto(string textoCifrar) {
            return Task.Run(() => {
                try {
                    return cipherManager.CifrarText(textoCifrar);
                } catch (Exception) {
                    logger.LogInformation(nameof(CifrarTexto));
                    return string.Empty;
                }
            });
        }
    }
}
