﻿using System;
using System.Text;

namespace JsonDerivedGenerator;

public class SourceStringBuilder
{
	private readonly string _singleIndent = new(' ', 4);

	public int IndentLevel = 0;
	private readonly StringBuilder _stringBuilder;

	public SourceStringBuilder()
	{
		_stringBuilder = new();
	}

	public void IncreaseIndent() => IndentLevel++;

	public void DecreaseIndent() => IndentLevel--;

	public void AppendOpenCurlyBracketLine()
	{
		AppendLine("{");
		IncreaseIndent();
	}

	public void AppendCloseCurlyBracketLine()
	{
		DecreaseIndent();
		AppendLine("}");
	}

	public void AppendMultipleLines(string text)
	{
		foreach (string line in text.Split(new[] { "\r\n" }, StringSplitOptions.None))
			AppendLine(line);
	}

	public void Append(string text, bool indent = true)
	{
		if (indent)
			AppendIndent();

		_stringBuilder.Append(text);
	}

	public void AppendIndent()
	{
		for (int i = 0; i < IndentLevel; i++)
			_stringBuilder.Append(_singleIndent);
	}

	public void AppendLine() => _stringBuilder.Append("\r\n");

	public void AppendLine(string text)
	{
		Append(text);
		AppendLine();
	}

	public override string ToString()
	{
		string text = _stringBuilder.ToString();
		return (string.IsNullOrWhiteSpace(text))
			? string.Empty
			: text;
	}
}