#region BSD License
/* Straight8.Framework Samples - FrameworkSample.cs
 * Copyright (c) 2001-2005 Jason Perkins.
 * All rights reserved.
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the BSD-style license that is 
 * included with this library in the file LICENSE.txt.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
 * files LICENSE.txt for more details. */
#endregion

using System;
using System.Diagnostics;
using Straight8.Framework;

namespace Samples.Framework
{
	public class FrameworkSample : ApplicationBase
	{
		/* Some simple cube data for rendering */
		static readonly float[] vertices = 
		{
			-0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f, 0.0f, 0.0f,
			 0.5f, -0.5f,  0.5f,  0.0f,  0.0f,  1.0f, 1.0f, 0.0f,
			 0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f, 1.0f, 1.0f,
			-0.5f,  0.5f,  0.5f,  0.0f,  0.0f,  1.0f, 0.0f, 1.0f,
			 0.5f, -0.5f,  0.5f,  1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
			 0.5f, -0.5f, -0.5f,  1.0f,  0.0f,  0.0f, 1.0f, 0.0f,
			 0.5f,  0.5f, -0.5f,  1.0f,  0.0f,  0.0f, 1.0f, 1.0f,
			 0.5f,  0.5f,  0.5f,  1.0f,  0.0f,  0.0f, 0.0f, 1.0f,
			 0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f, 0.0f, 0.0f,
			-0.5f, -0.5f, -0.5f,  0.0f,  0.0f, -1.0f, 1.0f, 0.0f,
			-0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f, 1.0f, 1.0f,
			 0.5f,  0.5f, -0.5f,  0.0f,  0.0f, -1.0f, 0.0f, 1.0f,
			-0.5f, -0.5f, -0.5f, -1.0f,  0.0f,  0.0f, 0.0f, 0.0f,
			-0.5f, -0.5f,  0.5f, -1.0f,  0.0f,  0.0f, 1.0f, 0.0f,
			-0.5f,  0.5f,  0.5f, -1.0f,  0.0f,  0.0f, 1.0f, 1.0f,
			-0.5f,  0.5f, -0.5f, -1.0f,  0.0f,  0.0f, 0.0f, 1.0f,
			-0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f, 0.0f, 0.0f,
			 0.5f,  0.5f,  0.5f,  0.0f,  1.0f,  0.0f, 1.0f, 0.0f,
			 0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f, 1.0f, 1.0f,
			-0.5f,  0.5f, -0.5f,  0.0f,  1.0f,  0.0f, 0.0f, 1.0f,
			-0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f, 0.0f, 0.0f,
			 0.5f, -0.5f, -0.5f,  0.0f, -1.0f,  0.0f, 1.0f, 0.0f,
			 0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f, 1.0f, 1.0f,
			-0.5f, -0.5f,  0.5f,  0.0f, -1.0f,  0.0f, 0.0f, 1.0f
		};

		static readonly VertexAttribute[] format =
		{
			VertexAttribute.Position,
			VertexAttribute.Normal,
			VertexAttribute.Texture2
		};

		static readonly int[] indices = 
		{
			0, 1, 2,
			0, 2, 3,
			4, 5, 6,
			4, 6, 7,
			8, 9, 10,
			8, 10, 11,
			12, 13, 14,
			12, 14, 15,
			16, 17, 18,
			16, 18, 19,
			20, 21, 22,
			20, 22, 23
		};
		
		static readonly uint[] texture =
		{
			0xff000000, 0xff000000, 0xffffffff, 0xffffffff, 
			0xff000000, 0xff000000, 0xffffffff, 0xffffffff, 
			0xffffffff, 0xffffffff, 0xff000000, 0xff000000, 
			0xffffffff, 0xffffffff, 0xff000000, 0xff000000
		};


		GraphicsWindow _window;
		VertexFormat _vfmt;
		VertexBuffer _vbuf;
		IndexBuffer _ibuf;
		Texture _tex;
		int _startTick;


		public override void Setup()
		{
			_window = new GraphicsWindow(T.Get("Framework Sample"), 640, 480);	

			_vfmt = new VertexFormat(format);
			
			_vbuf = new VertexBuffer(vertices.Length);
			_vbuf.CopyData(vertices);

			_ibuf = new IndexBuffer(indices.Length);
			_ibuf.CopyData(indices);

			_tex = new Texture(4, 4, TextureFormat.RGBA8);
			_tex.CopyData(texture);

			_startTick = Platform.TickCount;
		}


		public override void Dispose()
		{
			if (_window != null)
				_window.Dispose();
		}


		public override void Input(InputEventArgs e)
		{
			/* This will get easier when I port over the InputMapping classes */
			if (e.Kind == InputKind.Key && e.IsPressed)
			{
				switch (e.Key)
				{
				case Key.Escape:
					this.Dispose();
					break;

				case Key.G:
					System.Drawing.Bitmap image = _window.GrabScreen();
					image.Save("Screenshot.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
					break;
				}
			}
		}


		public override void Tick()
		{
			float elapsed = (Platform.TickCount - _startTick) / 1000.0f;
			Quaternion rotation = Quaternion.FromAngleAxis(elapsed, 0.8944f, 0.4472f, 0.0f); 

			Graphics.BeginFrame();
			Graphics.Clear(0.2f, 0.0f, 0.2f, 1.0f);

			Graphics.SetMatrix(GraphicsMatrix.Projection, Matrix4.Projection(1.0f, 1.333f, 0.1f, 100.0f));
			Graphics.SetMatrix(GraphicsMatrix.View, Matrix4.Translation(0.0f, 0.0f, -2.5f));
			Graphics.SetMatrix(GraphicsMatrix.Model, Matrix4.FromQuaternion(rotation));

			Graphics.SetTexture(0, _tex);

			Graphics.Draw(_vbuf, _vfmt, _ibuf);
			
			Graphics.EndFrame();
			Graphics.Swap();
		}

	
		/* Should I move this to ApplicationBase? */
		static void Main(string[] args)
		{
			ApplicationBase.Run(new FrameworkSample());
		}
	}
}
