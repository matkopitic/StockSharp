﻿namespace StockSharp.Community
{
	using System;
	using System.Runtime.Serialization;

	using Ecng.Common;

	using StockSharp.Messages;

	/// <summary>
	/// License message.
	/// </summary>
	[DataContract]
	[Serializable]
	public class LicenseInfoMessage : BaseSubscriptionIdMessage<LicenseInfoMessage>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LicenseInfoMessage"/>.
		/// </summary>
		public LicenseInfoMessage()
			: base(CommunityMessageTypes.LicenseInfo)
		{
		}

		/// <inheritdoc />
		public override DataType DataType => CommunityMessageTypes.LicenseInfoType;

		private byte[] _body = ArrayHelper.Empty<byte>();

		/// <summary>
		/// License body.
		/// </summary>
		[DataMember]
		public byte[] Body
		{
			get => _body;
			set => _body = value ?? throw new ArgumentNullException(nameof(value));
		}

		/// <summary>
		/// Copy the message into the <paramref name="destination" />.
		/// </summary>
		/// <param name="destination">The object, to which copied information.</param>
		public override void CopyTo(LicenseInfoMessage destination)
		{
			if (destination == null)
				throw new ArgumentNullException(nameof(destination));

			base.CopyTo(destination);

			destination.Body = Body;
		}

		/// <summary>
		/// Create a copy of <see cref="LicenseInfoMessage"/>.
		/// </summary>
		/// <returns>Copy.</returns>
		public override Message Clone()
		{
			var clone = new LicenseInfoMessage();
			CopyTo(clone);
			return clone;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return base.ToString() + $",BodyLen={Body.Length}";
		}
	}
}