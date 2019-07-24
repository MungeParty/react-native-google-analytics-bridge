using ReactNative.Bridge;
using System;
using System.Collections.Generic;
// using Windows.ApplicationModel.Core;
// using Windows.UI.Core;
// using Windows.Storage.Streams;
// using Windows.Security.Cryptography;

namespace RNGABridge
{
    /// <summary>
    /// A module that allows JS to share data.
    /// </summary>
    class RNGABridgeModule : NativeModuleBase
    {
        private static string SEED_KEY = "seed";
        /// <summary>
        /// Instantiates the <see cref="RNGABridgeModule"/>.
        /// </summary>
        internal RNGABridgeModule()
        {
        }

        /// <summary>
        /// The name of the native module.
        /// </summary>
        public override string Name
        {
            get
            {
                return "RNGABridge";
            }
        }

        public override IReadOnlyDictionary<string, object> Constants
        {
            get
            {
                return new Dictionary<string, object>
                {
                    {SEED_KEY, getRandomBytes(4096)}
                };
            }
        }

        [ReactMethod]
        public void randomBytes(uint size, IPromise promise)
        {
            promise.Resolve(this.getRandomBytes(size));
        }

        private string getRandomBytes(uint size)
        {
            //IBuffer buffer = CryptographicBuffer.GenerateRandom(size);
            //return CryptographicBuffer.EncodeToHexString(buffer);
            Byte[] buffer = new Byte[size];
            System.Random rnd = new System.Random();
            rnd.NextBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

    }
}