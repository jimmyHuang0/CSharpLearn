using System;
using System.Collections.Generic;
using System.Text;

namespace CommonItf.RWItf
{
    public struct ITag
    {
        public struct Name
        {
            public string NameInMaster;
            public string NameInSlave;
        };
        public Name name;

        public enum emQuality
        {
            good,
            bad
        }
        public struct Value
        {
            public string value;
            public string TimeStamp;
            public emQuality Quality;
        };
        public Value value;

        public struct Address
        {
            public string deviceName;
            public string instanceName;
            public string groupNum;
            public string offsetNum;
            public string bitNum;
        };
        public Address address;

        public struct Type
        {
            public string type;//byte/int/.../struct/
            public string TypeName;
            public string isArray;
            public string isArrays;
            public string isPointer;
            public string isReference;
            public string isBitValue;
        };
        public Type type;

        /*
         e.g:
		a:array[0..1]of b;//this button a
		--name:
			--sName:a
		--type:
			ToT:struct
			typeName:b
			isArray:true
			isPointer:false
		--size
			--cntByte:
			--cntNumer:2
		--commit: this button a
         */



    }






}
