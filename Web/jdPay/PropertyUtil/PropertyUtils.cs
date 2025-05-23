using System;
using System.Collections.Generic;
using System.Web;

namespace jdPay.PropertyUtil
{
    public class PropertyUtils
    {
        public static Dictionary<String, String> propertyDictionary = new Dictionary<String, String>();
        static PropertyUtils()
        {
            propertyDictionary.AddOrPeplace("wepay.merchant.num", "110310894002");
            propertyDictionary.AddOrPeplace("wepay.merchant.rsaPrivateKey", "MIICeAIBADANBgkqhkiG9w0BAQEFAASCAmIwggJeAgEAAoGBANgBj8/FlUteNSXGoUud4ejbYRhwlXeya6dpGIoIE7r6AjN7dxpwxLxyWP9FokY4C/Vz7zK+/bxt19FD3K28RpB2KTUgaAG6srNnejIwg0MCiTbxSfWxXX2lQRrFzXwOjSAR6HR7nMdawGg6ToasXzUEqv6vIQSlYxzPtSdaoylZAgMBAAECgYEA0H3JarmCncmjsP+lBhCxUgoWEPnyOyObJ26YgfrD2JCh+UEtt/aq3l3cqyByPiaw3Ez3z1psHSlEy7cd1Q/KZrW1FoVG1gprLalTdw82fZVpnjjr0s1EZ3zeYb4OjdEcTAEp3cu843IE02CqkzatnzMh3noNpmUgg42kUt1FwQUCQQDuvjkozUTm1+S4J2P2+VbK9yychqWiJ7eVE/wI6xkoB9DhU4w740a8JA8UGRktDh3kesr0uyGTDdWSyuxn/uxbAkEA556bTKurPQPCKl4PBKzCjcQvF3qy5w4YEOviYBPkweMRwj2/XSXAGMzZh5qEjlb+0QZk7oCciJo+hB0xHox/WwJAMhyDaukLGVkfjPfXp7NWYGvZVVF92rdzdTson8aZFSnu0hzzRm7CHiODdrh97FMWOyr7BrtwpKk2twUY8gs0GQJBAOUPkUyA1eeQiPx3aujXpcyoAV56BOXGpXxOm+Eiq3AoDU8I2/DVvaWJKXQXFxLh7D1x0m2gma3qxPrJF+O7VNMCQQC2Jf95gzfq2IJ4OrmTenhFRyI7BMI/w6B3TG4d0lsbWi+tL5fbzRLSoku3Sj88uD1eKxHn3E+z23ShIDZoTzw8");
            propertyDictionary.AddOrPeplace("wepay.merchant.desKey", "jDTgV4Yq962o/aLHhnqtwatdtXCd7zh6");

            //propertyDictionary.AddOrPeplace("wepay.jd.rsaPublicKey", "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDYAY/PxZVLXjUlxqFLneHo22EYcJV3smunaRiKCBO6+gIze3cacMS8clj/RaJGOAv1c+8yvv28bdfRQ9ytvEaQdik1IGgBurKzZ3oyMINDAok28Un1sV19pUEaxc18Do0gEeh0e5zHWsBoOk6GrF81BKr+ryEEpWMcz7UnWqMpWQIDAQAB");

            //MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCKE5N2xm3NIrXON8Zj19GNtLZ8xwEQ6uDIyrS3S03UhgBJMkGl4msfq4Xuxv6XUAN7oU1XhV3/xtabr9rXto4Ke3d6WwNbxwXnK5LSgsQc1BhT5NcXHXpGBdt7P8NMez5qGieOKqHGvT0qvjyYnYA29a8Z4wzNR7vAVHp36uD5RwIDAQAB
            propertyDictionary.AddOrPeplace("wepay.jd.rsaPublicKey", "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCKE5N2xm3NIrXON8Zj19GNtLZ8xwEQ6uDIyrS3S03UhgBJMkGl4msfq4Xuxv6XUAN7oU1XhV3/xtabr9rXto4Ke3d6WwNbxwXnK5LSgsQc1BhT5NcXHXpGBdt7P8NMez5qGieOKqHGvT0qvjyYnYA29a8Z4wzNR7vAVHp36uD5RwIDAQAB");
            propertyDictionary.AddOrPeplace("wepay.server.query.url", "http://paygate.jd.com/service/query");
            propertyDictionary.AddOrPeplace("wepay.server.refund.url", "http://paygate.jd.com/service/refund");

            propertyDictionary.AddOrPeplace("wepay.server.query.refund.url", "http://paygate.jd.com/service/queryRefund");
            propertyDictionary.AddOrPeplace("wepay.server.uniorder.url", "http://paygate.jd.com/service/uniorder");

            propertyDictionary.AddOrPeplace("wepay.server.revoke.url", "http://paygate.jd.com/service/revoke");
            propertyDictionary.AddOrPeplace("wepay.server.fkmPay.url", "http://paygate.jd.com/service/fkmPay");
            
        }

        public static String getProperty(String key)
        {
            return propertyDictionary.getVaule(key);
        }
    }
      
    
}