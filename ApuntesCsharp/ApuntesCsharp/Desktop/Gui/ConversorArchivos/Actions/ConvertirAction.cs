﻿using System;
using System.Threading.Tasks;
using ConversorArchivos.Actions.Interfaces;
using ConversorArchivos.BusinessManager.ConversorManager.Interfaces;

namespace ConversorArchivos.Actions {
    internal class ConvertirAction : IConvertirAction {
        private readonly IConversorManager conversorManager;
        public ConvertirAction(IConversorManager conversorManager) {
            this.conversorManager = conversorManager;
        }

        public Task ConvertTo(string folderPath, string extensionInicial, string extensionFinal) {
            return Task.Run(() => {
                try {
                    conversorManager.ConvertTo(folderPath, extensionInicial, extensionFinal);
                } catch (Exception) {
                    throw;
                }
            });
        }
    }
}