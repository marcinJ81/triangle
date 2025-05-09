﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle3
{
    public interface IValidation
    {
        void ValidationParameters(FigureDescriptionParameters figureParameters);
    }

    public class Validation : IValidation
    {
        public void ValidationParameters(FigureDescriptionParameters figureParameters)
        {
            if (figureParameters == null)
            {
                throw new ArgumentNullException(nameof(figureParameters), "Parameters cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(figureParameters.FigureType))
            {
                throw new ArgumentException("Figure type must be specified.");
            }

            //if ()
            //{
                
            //}

            switch (figureParameters.FigureType.ToLower())
            {
                case "triangle":
                    ValidateTriangleParameters(figureParameters);
                    break;

                case "square":
                    ValidateSquareParameters(figureParameters);
                    break;

                case "circle":
                    ValidateCircleParameters(figureParameters);
                    break;

                default:
                    throw new NotSupportedException($"Figure type '{figureParameters.FigureType}' is not supported.");
            }
        }

        private void ValidateTriangleParameters(FigureDescriptionParameters parameters)
        {
            if (!parameters.BaseSide.HasValue || parameters.BaseSide <= 0)
            {
                throw new ArgumentException("Triangle base must be greater than zero.");
            }

            if (!parameters.Height.HasValue || parameters.Height <= 0)
            {
                throw new ArgumentException("Triangle height must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(parameters.Name))
            {
                throw new ArgumentException("Triangle name must be specified.");
            }
        }

        private void ValidateSquareParameters(FigureDescriptionParameters parameters)
        {
            if (!parameters.Side.HasValue || parameters.Side <= 0)
            {
                throw new ArgumentException("Square side must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(parameters.Name))
            {
                throw new ArgumentException("Square name must be specified.");
            }
        }

        private void ValidateCircleParameters(FigureDescriptionParameters parameters)
        {
            if (!parameters.Radius.HasValue || parameters.Radius <= 0)
            {
                throw new ArgumentException("Circle radius must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(parameters.Name))
            {
                throw new ArgumentException("Circle name must be specified.");
            }
        }
    }
}
