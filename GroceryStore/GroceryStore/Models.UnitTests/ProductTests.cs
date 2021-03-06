﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Models.UnitTests
{
    /// <summary>
    /// Summary description for ProductTests
    /// </summary>
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Name_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testName = "Apples";

            //Act
            var product = new Product { Name = testName };

            //Assert
            Assert.AreSame(testName, product.Name);
        }
        [TestMethod]
        public void PhoneNumber_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testCategory = "Fruits";

            //Act
            var product = new Product { Category = testCategory };

            //Assert
            Assert.AreSame(testCategory, product.Category);
        }
        [TestMethod]
        public void Price_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testPrice = 5.55m;

            //Act
            var user = new Product { Price = testPrice };

            //Assert
            Assert.AreEqual(testPrice, user.Price);
        }
        [TestMethod]
        public void Picture_ShouldBeSetAndGottenCorrectly()
        {
            //Arrange
            var testPictureUrl = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxMTEhUTEhIVFhUVFhgYFxgXFxUVFxcXFRcXFxgaFxUYHSggGBolGxUXITEhJSkrLi4uFx8zODMtNygtLisBCgoKDg0OGhAQGi0lICUtLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLf/AABEIAPAA0gMBIgACEQEDEQH/xAAcAAABBAMBAAAAAAAAAAAAAAAAAgMEBQEGBwj/xABCEAABAwIDBQUGAwUGBwEAAAABAAIRAyEEMUEFBhJRYSJxgZGxBxMyocHwUtHhFCNCcpIzYnOCsvEIFUNTY6KzJP/EABoBAAIDAQEAAAAAAAAAAAAAAAACAQMEBQb/xAArEQACAgEEAgEDAgcAAAAAAAAAAQIDEQQSITEFQRMiUZEy0SMzQ2FxgaH/2gAMAwEAAhEDEQA/AO4oQhAAhCEACEIQAIQhAAhCEACELBQBlCrm7boF5Z7wSMz/AAzy4sp6KwChNPolprsyhCrNqbco0PjdJ/C258eSiU4xWZMgs0LQsfv26SKTABzdcqrdvtivxN/oCyS19SeBd6OooXN8H7QqrTFWm1w5jslWdH2kYaYe2o3rAcE8dZTL2CkjdUKt2Zt3D4gTSrMd0kBw72m6sloUlLlDAhCEwAhCEACEIQAIQhAAhCEACEIQAIQhAAhCEACEJnGVuCm95/ha539IJQB5wFWq/H1MPQc4+9xDmtESBLzciMhnI0C9GYGh7qkxjnl/A0AudEmBmVxn2OYEvxr6744adNxBP46hj04luHtI3je2n+z4biLn/wBo9okBpB7IPM+iyOyFcXJl97eVH7GN5d9uJzqWFdAFnVBBnoz81qLq5OZJnn93KqsPRe3Np8ipQeQMiuBffZZLMmZGx0mJTXFZIdWtcHyTQqKtZFE138lXYh0qdUeFFqBWwAguJBkEgjKDkt03W9o1egQzEE1aWWnG3lDtR0K1J1NINJaa7XDlBnB6L2PteliaYqUX8TT5g8nDQqevPGw9r1sM/jovLTFxAIcORGq7NulvTTxrLdmo34mEif5hzC6un1Ss4fZZGWTYUIQtYwIQhAAhCEACEIQAIQhAAhCEACEIQAKg39rFmzsW4GD7ioB3uaR9VfLVfajUjZmI6hg7wajAR5FRLpj1rMkjUPYtsSnVwtSrVaXfvS1olwADQOWsldA2hsdraf7psR/CJv3dVo/sv3jwmFwBbWrsY41ah4SZdFo7IvorjEe1LBAw0VXxyaAPmVQoVuOWlk1Wae6yb2xbK3F0ScnGfMKtfQdqVnH75YWtUDqbKjC49oODQJ0cCCYKlhwN7eC5ttMdxiuospeJpogigTnB8B+SRWwTXfE1p8CJ8lZFgS20wfvNIqI/YoNer7LZo2O5x+qr62CaMuIX1v6Laa9LQKoxTEs6UiCi/Zhc8TfT1QMKTp5XUmrE5IpUhOX0hVKLAjijzCVg8e/D1BVpEte3IjUag9CthoYXi1nvvHiVH2nssAZR1H5K3Y1ygydd2BtdmKoMrU8nZjVrhYgqxXG/Z9t84SuaVQ/uKpz0Y+wDjyGhXYwV2NPb8kM+y6LyjKEIV4wIQhAAhCEACFhaHv5v1+zh1HDFprXDnkjhpG2hHad00UN4LK65WS2xNp23vBh8I3ir1WstZs9p38rcyuf7R9rkmMNhp5Oqujx4Wg+q5visWatQvquqV6hMlxPD4SQbdwCVUxTRHDTDLX7ZcfmqJWP0eg0via0k7E2/wjcjv7tN/wAL6Q5AUwfUpA302rP9q3xpNj0Wr4HarmmYBjx9cltGztvUnwH8LTycfR30Kr3yNdmkph/TX4HHb1bUcP7eOradP6tWvbxV8XVp8WIrVHtDmEhx7PxgWaLaro2Ho0w2dDoqffHgODqQADxU/wD6M+iHJtdmTdXHKjBL/RoWzsBxMJj+KB0ylWeI2a1obBEnPv8AuEmgeBpH94+gUPFYt0j5JU8myFklFYF4nBwJDh1P0SMDtWrQHacS0aGJA8Vmhha744aZIi2Q9Umpufi6pJc5jB1M+cJ2otYZmvati42LJsGzt5aT/wCITyJWx4Ks11wRHeFzCtuBiRdr2O/lMH5qbszYGPpEcNSoznPC4eSr+JLpnEn4+Tf0/wDTpOJp2la9tTJOsr4ym0BzqdS17Fp+qo9q7RqGzqZF+YIHiqrI8dGWejujzt/BDqVoOado4i/5pZ3dxro4cHVcCJBAkEHkdQnKO5m0X2GEqD+YtaPmVn+GfpMzbWXGysYMp8J+a2ZmHZVbwm5IyFz5DVQti+zOuOF1fEhnNlNsn+smPkugbL2NRoD92y+rieJx/wAx06LZTRPH1IZQ+5o2zfZ697g+u/hZN2AHjcBzdPZldGo0w1oa0QAAAOQGSWha66o19Fiil0CEIVpIIQhAAsIWke0nfYYKn7qkQcQ8GB/22kHtnryChvA0IOctqE+0LfpmEaaFIh1dwgiT+7BGbiNei4hXxr6ji5xJJzPqo2IxD3uLnuc5zjJcSSSTqSUoVBGQyHjzKzzbZ6bQ6aFK/uSH4iwAEff6KTs7AVKpsDFrmPkoDXcx81sGzHGnUFw4QDANhb1VZ1m8RyuyY3deo4iG9nWICj47Dtp24crX5jkt5p7RY2nxGO76Ko2i2nXAcTEmLRbXLuU9GKGpnJ4kuCh2TtWq13C2oYz4XCQBGd8gmdpberVpZ2fdnQCSeG8z4K8wexaXvDwvOUZefyV9htgUGAQwETr3JduXkmdung+Vk5wC91iXGRl8swrHCbAqi7WOMrpWHwVJoHDTaOoaFPoMEp9pTLyCj+iJz7D7r4sgwHttLSXNF+olWdHdLGm7sTwT/CADHct5a4JYfZSq0ZJ+Rtfpfg53jd0sY3tNxLnR1iekZKjq7QxeGIFVpIGc6+IyXX3wqPbOz2VWOaQCCI6juUSrXouo8hv+m2Ka/wAGj4bbzHxeDyOaTjNoUTYxPzv6rWNrYB1Go5h0Jg9yh+8J6wkwdRaSvuPR1Pcrek4Z4pVH8WHeey4kn3R5D+6bW0XV2ukSMl5YpYtwBANjmNJ5rsPsn3u9+z9lrOmoyeAmZcwRaeY9FfVJ9M4XlfH7P4sOvf7nR0IQrzgghCEACEIQAIQhAFXvJtqng8O+vUMBo7I/E8g8LR3leZttbXqYms+rVdLnuk5wOg6ALevbbvGamIGEaexQhzom9Rzde5p/9iuYvfN9fvJUzeWdjQ0qMdz7Y4SlB902ak25JTRfqq2deoltaREgiRI6jKR5K2wlXh8TeeSqGn8RMgQB3adFIZVHCSSZEcI53vfRIa92Vg2attSWwcpFxfxVf+2ST8QGYIzga96ralYtaQZ45BGUARJnzSKVQwdCBblBzUIEki/2RtHtTxwLmTNv91v2z8eHsBlchFWDYW1681s2wts8LeEmPNMjPqqdyyjo9OuOacdjGtEz3j7zWlnaBmSYhQMft1zsnGBrzOqNxjjo5SZvv/OmZT3mYhNV95GMPMSAToCcp8ly6ttDhkZ5XHXqotXaT8uLsnS94ylRuZqj42D7OvUt5aTrEwpIeDDgZabiNVxyjtVzcjYggzN5zCt9j7yvpyJtyJJ8ghT+4tnjcLNZb7/4QdkgXMk/L6LQ2yx0gkEZFX+394PfR3H5qgr4wkugAcQgiMssvJSuWbqFKFSjLsyKRIJGTY4ukmE9gMZUw9VlWmYc0yCD4EHoVCYClt+GZzJB1hP0RYt8Wmem93trsxWHp12ZPFxycLOHgZVkuS+xPbJmrhHazVZnbIOA6ZFdaWhPKPF6mr4rXEEIQpKAQhCABRto4oUqVSqcmMc4/wCUE/RSVpftcx5pbNqwb1HNp+Djf5AqGNBbpJHnramOdWquqPMve4ucb3JUJpvCyXXKQ9Unfj1wOUynQYTDE93JWaa2SG1AGzm4zM6ZQQdTmhr5zTQ6rJddIzTGWGPPqdECpbqkVq0xYCABb1PVNByhIf5OSTxEGdVkVzxSTeZTL6pdcmUhpUolzz2W3/MKmRccs9eibqYgm/M5aWTNTEcZkNaLRDRAsIlIkQD1ulaLozSRKpV5a4EdoxHS97eSbDtExUc2ZbMdfzT1OmSCdBdRIaMsmXusBy070t5bwth0m8iI4b2vrIUZxSWFL6HUsMsKDGFji4niHwgepPJR308lloFoOZMjll9+Cl1MNww7MC5UKWC36fY1TY0EdoXEkQbHl5XTB7J6J6n8UxaQQDy5SlvwxIJFwPzTqRXYsIsty9qnD46jUmxcGn+V54T6r0mvLLnD4gbt4Yty/WF6ewFbjpU3/iY0+YBWqp8Hk/LwSmpEhCEK05AIQhAAuY+3uvGDot/FX/0sd+a6cuT/APEAf3GF/wAV/wDpCiXRbR/MRw8rAcnHNHhN0kCMvuVSztRyYCepmIORBEJsAaLIKVmiPA6XyZNybyhyKDrickEx3aJS1PgCYjuQBNklOUWyYkDvyQTkSClOfYQMs+qS53RYa209fVBLYtpS3nJNA3S3lQyyMuB7DwZmcjERnp4JVIEyB3psZTFphYa7lzSstTJBBABmzrZjQ6pKafmpVAAEdyVrgtjIVQPaGWiuHAHX77lRk3kaHkrak+4J6W5wq5xY7nkbeDYZxb9EyHkSOn1SuNvauZJkfNNOqSYOeXdGaaCZEp8GSOwZzzjmDqvSO6j+LB4c/wDhZ8mgLzZXfN9AIE5wMl6S3RbGCw/+Ez5gFa6TzvmHlRLdCEK84YIQhAAuU/8AEAz/APPhjyquHmw/kurLnPtyw/FgGOj4KzfJzXj8lD6LaXixHAmi9+SQ4JzglLqUrDnqqWdyIyl1GZEZEZZ96kMwhI4tBmkvYlLUNVWAGxmySck6Woq0oAuLibfXqoLENMac0oJxggeCxwckExEQsAJzgkJICBpAGnMpT3ZLNOQD1ssOao9krocc+0Wznr/skAEg9E40CDz0WWMgXyRgfI1yUvDski6a9zZP0CBKhoZSwSHU4tNuY1UlroyUOniCJjI2Kk0X2uJtHclaJU8EQOJnohuZcbpxlMEG8fcJdNluHrM8tLqxISUxmCRA1+x9V6h2VQ4KNJn4abG+TQF513c2a6tiKFMfxVWgjoDJP9IK9KhXwRwvJTzJIEIQnOWCEIQALXPaFsz9o2fXp6hvGO9naHotjSKjQQQciIPiglPDyeU6GDcBIbOiyzC2PEDMroW8exhRrPY0WBkBa5jKMQRkb9yokduqzciiqUo0USs1XVWlN1XYinfspDZEgzZOOIsDcD6p1tAHNFakINvLml9lyXBF94kTKXwlApkxCYjBkGywAktZdSGHIEWCCMMyKay5meX30WaKWWSbZapPZZjgR7rSIThaA3+9PhCw05pTyCEyAwy8TlqlU2ye75pdOj2ZkZ5ap3D0xrKhkjcCCI1TtOkZHXqnGUZKfDLiUCN+yO2gZgXMwPvkpmHwxJhP4SjJmLK4wmE56p4mayeC89mOyJxfvSOzTY6P5nQB4wSutqi3O2f7nDi13GT6BXq0RWEcHUWb5tghCFJQCEIQAIQhAGh+0LAw5tSLH1A/Jc6xVPMeX6Ltu8WB99Qc3UdoeAK4ztBhaS3lkqpo6OjllYKA5wVDrsAKmYiZnkolR05qpnXgRuEynHrBMFLm8QlZoiiM+imHMKnPWJtEITGaIjWgCxv3JTBKk06IKy2hyChslRGyzwlNMMd2vVSzTgCeaRUZcxlP3ZRkbBgVJcYAAOhuhrJgaD6rFEQQTcTlzTzDLjFugTZE2mWs5KXTpi6xQbCcYwnL7hDZGGZEhO0qMzcFZ4TYmbj9FJwNL1QuSufCJuDo6LZ939nGpUa2PFVGAoy4Lom6GBgGp4D6q6COTqrcJmyMbAAGQEeSUhCuOQCEIQAIQhAAhCEAYIXI/aBs33VckCGuuPHMeBXXCVr2+uyhiMO4D42S5vW12+KWSyi6izZNM4PinQoVWyk4+xgquc4LOz0VfKHDUBulAzJnL7so+YMf7LPGNEjNcUSBU1OaTU6povEDnqlMHzQN2PMqWjROtqHuCZYL6p5lKUrHSEvdIvzSHshokXJznTuTlKnxGNb6SkveCANQbqBtvAluaWyxkJfFMap5tAiZEEHI5z3JhWhTAQOKPiB8Yt6qTQBiZjQnoeibNP07k7RBkW/VLnIbcIdpM8RkNPFTsMyAAMyoosM81Z7OolxFlZEx3PCL/YmCc5wa3M2H1XTsJhxTYGNyAVFups3gZxuFyLd3NbECtUVhHm9RZukZQhCYzghCEACEIQALBKymazkAIrVoVNtDaEA3S8fiIWobZx0SglGlb84Ue8NVgs7MDQx9VpL6kLc9q4zikFahjKEEkZeiqnD2jraTVbVtkMMfn1SmlM5a2CUDdZ3k7VdiaJAmZzhPMePH5KEw59yfm0x4pcl8eSYX8k9RdadMvFQ6bpHVKa4xc5KCwlvFrKPTaQfv0Trqri0ST0GlrIpgm8wQLfohcE9j1OpJnlnZS8NMqLRB55/NWdJpDeEyLmySTDAvhBPPQGE+ygRNrix6Sm2NAuBYZ9FMw0Wm0371CYs2GGwhMSBHqt03X2NxEOd8I+fRV2x8B7xwOTQt6wLA0AAWC11Q9s4Gv1a/REtKWVk80qPTKfatJxBxCAhBAIQhAAhCEACYrtT6S5qANb2nTK0nblEwV03FYaVru0tlTNkEo41tGmZKqajV0vaewM7LWsdsI8lBbFmmV6Pgo0ELYMVspwVfUwjholcUzXVdKPTITXBO0yEOoJPuCMlTKpM3165rtC2kypPCYHVRQTqE7TxMZqp1tHQq1lb9kxgixS2xI68vRQBijOSW7EO0H33qVBjy1da9lsamQnvty0CfoV4Hfa6oRUenKWHqOOpR8JRLyEfSLqrtBg174+g5KXsyu+o4cIgTnr+ia2PutUeQS1dE2FuxwASFbCpI52o8hKSwTNhUCGhbPhqabweB4QrKlSV6OROWWZptT7QsNalqSsEIQgAQhCABCEIAEIQgDBCZq0AU+hAFRidmg6KnxewwdFtxCQ6mEE5OdYvdsHRU+J3X6Lq78KCmH4AclGCVJnHK+6c6Kvq7oO0C7cdmN5LA2W3kjA6taOEv3Uq6NSG7q19KZ+S743ZreQTjcCOSjA3zs4VR3IxLv+n5kK0wvs6qn4oHzXZm4UcksYcKdofPI5jgvZywfESfJbDgd0aNPJg8YW3iiEoU0YQjtk/ZU4fZjW5AKdTw4ClBqzCkTI22mnAFlCCAQhCABCEIAEIQgAQhCAP/2Q==";

            //Act
            var product = new Product { Picture = testPictureUrl };

            //Assert
            Assert.AreSame(testPictureUrl, product.Picture);
        }
    }
}
