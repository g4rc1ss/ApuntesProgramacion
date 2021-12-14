using System;
using Microsoft.Extensions.Logging;
using WebAPI.Backend.Business.Actions.Cipher.Interfaces;
using WebAPI.Backend.Business.BusinessManager.CipherManager.Interfaces;

namespace WebAPI.Backend.Business.Actions.Cipher {
    internal class CipherAction : ICipherAction {
        private readonly ILogger<CipherAction> logger;
        private readonly ICipherManager cipherManager;

        public CipherAction(ILogger<CipherAction> logger, ICipherManager cipherManager) {
            this.logger = logger;
            this.cipherManager = cipherManager;
        }

        public string CifrarTexto(string textoCifrar) {
            try {
                return cipherManager.CifrarText(textoCifrar);
            } catch (Exception) {
                logger.LogInformation(nameof(CifrarTexto));
                return string.Empty;
            }
        }
    }
}
