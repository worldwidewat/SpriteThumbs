SpriteThumbs
============

This is a handy little library that takes a collection of images and generates a single sprite for efficient display of thumbnail images on your site.

## Installation

From the Package Manager Console in Visual Studio, run `Install-Package WorldWideWat.SpriteThumbs`

That's it!

## Configuration

Some code will be added to your web application's App_Start folder. Edit this file to change the image generation parameters and feed SpriteThumbs the collection of images to process.

```CSHARP
public static class SpriteThumbsConfig 
{
  public static void PostStart() 
	{
		var configuration = SpriteThumbsGlobalConfiguration.Configuration;

		var outputFolder = HostingEnvironment.MapPath("/App_Data/SpriteThumbsOutput");

		if (outputFolder != null && !Directory.Exists(outputFolder))
		{
			Directory.CreateDirectory(outputFolder);
		}

		configuration.SetSpriteOutputPath(outputFolder);

		// Feed SpriteThumbs your images here
		foreach (var thing in _myRepository.GetThings())
		{
			configuration.RawImages.Add(new RawImage
			{
				Id = thing.ThingId,             // Assign each image an Id
				FullFilePath = thing.ImagePath  // Tell SpriteThumbs where your image lives on disk
			});
		}

		// Tweak other sprite generation parameters here (like thumb size and image quality)

		var spriteGenerator = new SpriteGenerator(SpriteThumbsGlobalConfiguration.Configuration);

		spriteGenerator.Generate();
	}
}
```

When your application starts, SpriteThumbs will generate a single image containing thumbnails for all of the images specified, as well as a .css file with the necessary styles for displaying each thumbnail. The Id assigned to each image in the code above is used to index into generated image.

## Usage 

The easiest way to display a thumbnail image is to create a HtmlHelper extension method:

```CSHARP
public static MvcHtmlString ThumbImage(this HtmlHelper helper, string thingId)
{
  var builder = new TagBuilder("div");

  builder.AddCssClass(SpriteThumbsConfiguration.GetThumbClassName());
  builder.AddCssClass(SpriteThumbsConfiguration.GetImageClassName(thingId));

  return new MvcHtmlString(builder.ToString());
}
```

And then use it in any view you choose:

```CSHARP
@Html.ThumbImage(Model.ThingId)
```

## Questions or Problems?

Feel free to log an issue or hit me up on Twitter - [@pwninstein](http://twitter.com/pwninstein)

I hope you enjoy!
