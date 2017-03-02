using System;
using System.Security.Cryptography;
// ReSharper disable InconsistentNaming

namespace Kit.Core.Encryption
{
    /// <summary>
    /// Тип алгоритма
    /// </summary>
    public enum AlgorithmKind { AES, TripleDES }

    /// <summary>
    /// Фабрика алгоритмов
    /// </summary>
    public class AlgorithmFactory
    {
        /// <summary>
        /// Получить симметричный алгоритм шифрования
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static SymmetricAlgorithm GetSymmetricAlgorithm(AlgorithmKind type)
        {
            SymmetricAlgorithm sa;

            switch (type)
            {
                case AlgorithmKind.AES:
                    sa = Aes.Create();
                    break;

                case AlgorithmKind.TripleDES:
                    sa = TripleDES.Create();
                    break;

                default:
                    throw new NotSupportedException("Unknown algorithm");
            }

            return sa;
        }
    }
}
