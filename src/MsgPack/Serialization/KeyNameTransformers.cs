#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2016 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;
using System.Text;

namespace MsgPack.Serialization
{
	internal static class KeyNameTransformers
	{ 
		public static readonly Func<string, string> AsIs = key => key;

		public static string ToLowerCamel( string mayBeUpperCamel )
		{
			if ( String.IsNullOrEmpty( mayBeUpperCamel ) )
			{
				return mayBeUpperCamel;
			}

			if ( !Char.IsUpper( mayBeUpperCamel[ 0 ] ) )
			{
				return mayBeUpperCamel;
			}

			var buffer = new StringBuilder( mayBeUpperCamel.Length );
			buffer.Append( Char.ToLowerInvariant( mayBeUpperCamel[ 0 ] ) );
			if ( mayBeUpperCamel.Length > 1 )
			{
				buffer.Append( mayBeUpperCamel, 1, mayBeUpperCamel.Length - 1 );
			}

			return buffer.ToString();
		}

		public static string ToUpperSnake( string mayBeUpperCamel )
		{
			if ( String.IsNullOrEmpty( mayBeUpperCamel ) )
			{
				return mayBeUpperCamel;
			}

			var buffer = new StringBuilder( mayBeUpperCamel.Length * 2 );
			int index = 0;
			for ( ; index < mayBeUpperCamel.Length; index++ )
			{
				var c = mayBeUpperCamel[ index ];
				if ( Char.IsUpper( c ) )
				{
					buffer.Append( c );
				}
				else
				{
					buffer.Append( Char.ToUpperInvariant( c ) );
					index++;
					break;
				}
			}

			for ( ; index < mayBeUpperCamel.Length; index++ )
			{
				var c = mayBeUpperCamel[ index ];
				if ( Char.IsUpper( c ) )
				{
					buffer.Append( '_' );
					buffer.Append( c );
				}
				else
				{
					buffer.Append( Char.ToUpperInvariant( c ) );
				}
			}

			return buffer.ToString();
		}
	}
}